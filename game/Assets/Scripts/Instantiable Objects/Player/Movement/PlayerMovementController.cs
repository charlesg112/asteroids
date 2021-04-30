using UnityEngine;

public class PlayerMovementController : BorderBound
{
    public Rigidbody2D body;
    public float maxSpeed;
    public float mass;
    private bool leftMovementLocked, rightMovementLocked, bottomMovementLocked, topMovementLocked = false;

    protected override void BorderCollisionEvent(Collider2D collider)
    {
        switch (collider.gameObject.name) {
            case "left":
                leftMovementLocked = true; break;
            case "right":
                rightMovementLocked = true; break;
            case "top":
                topMovementLocked = true; break;
            case "bottom":
                bottomMovementLocked = true; break;
        }
    }
    private void ResetLocks(float horizontalMovementInput, float verticalMovementInput)
    {
        if (horizontalMovementInput > 0) leftMovementLocked = false;
        else if (horizontalMovementInput < 0) rightMovementLocked = false;
        if (verticalMovementInput > 0) bottomMovementLocked = false;
        else if (verticalMovementInput < 0) topMovementLocked = false;
    }

    private float AdjustHorizontalMovementToLocks(float horizontalMovementInput)
    {
        if (leftMovementLocked && horizontalMovementInput < 0) return 0;
        else if (rightMovementLocked && horizontalMovementInput > 0) return 0;
        return horizontalMovementInput;
    }
    private float AdjustVerticalMovementToLocks(float verticalMovementInput)
    {
        if (bottomMovementLocked && verticalMovementInput < 0) return 0;
        else if (topMovementLocked && verticalMovementInput > 0) return 0;
        return verticalMovementInput;
    }
    void AdjustMovement(float horizontalMovementInput, float verticalMovementInput)
    {
        ResetLocks(horizontalMovementInput, verticalMovementInput);
        float currentHorizontalSpeed = body.velocity.x;
        float currentVerticalSpeed = body.velocity.y;
        float adjustedHorizontalMovementInput = AdjustHorizontalMovementToLocks(horizontalMovementInput);
        float adjustedVerticalMovementInput = AdjustVerticalMovementToLocks(verticalMovementInput);

        Vector2 directionNormal = GetDesiredDirectionNormal(adjustedHorizontalMovementInput, adjustedVerticalMovementInput);
        if (directionNormal.magnitude == 0)
        {
            //Debug.Log("Normal is 0");
        }

        float horizontalMaxSpeed = Mathf.Abs(directionNormal.x * maxSpeed);
        float verticalMaxSpeed = Mathf.Abs(directionNormal.y * maxSpeed);
        float finalHorizontalSpeed = CalculateFinalSpeed(currentHorizontalSpeed, adjustedHorizontalMovementInput, horizontalMaxSpeed);
        float finalVerticalSpeed = CalculateFinalSpeed(currentVerticalSpeed, adjustedVerticalMovementInput, verticalMaxSpeed);
        
        body.velocity = new Vector2(finalHorizontalSpeed, finalVerticalSpeed);
    }

    float CalculateFinalSpeed(float currentMovement, float inputMovement, float maxSpeed)
    {
        float expectedAcceleration = inputMovement / mass;
        float expectedFinalVelocity = currentMovement + expectedAcceleration;
        if (Mathf.Abs(expectedFinalVelocity) > maxSpeed)
        {
            if (expectedFinalVelocity < 0) expectedFinalVelocity = -maxSpeed;
            else expectedFinalVelocity = maxSpeed;
        }
        return expectedFinalVelocity;
    }

    Vector2 GetDesiredDirectionNormal(float horizontalMovementInput, float verticalMovementInput)
    {
        Vector2 output = new Vector2(horizontalMovementInput, verticalMovementInput);
        return output.normalized;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        AdjustMovement(horizontalMovement, verticalMovement);
    }
}
