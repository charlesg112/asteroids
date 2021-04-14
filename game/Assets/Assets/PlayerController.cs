using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float maxSpeed;
    public float mass;

    void AdjustMovement(float horizontalMovementInput, float verticalMovementInput)
    {
        float currentHorizontalSpeed = body.velocity.x;
        float currentVerticalSpeed = body.velocity.y;
        Vector2 directionNormal = GetDesiredDirectionNormal(horizontalMovementInput, verticalMovementInput);
        if (directionNormal.magnitude == 0)
        {
            //Debug.Log("Normal is 0");
        }
        float horizontalMaxSpeed = Mathf.Abs(directionNormal.x * maxSpeed);
        float verticalMaxSpeed = Mathf.Abs(directionNormal.y * maxSpeed);
        float finalHorizontalSpeed = CalculateFinalSpeed(currentHorizontalSpeed, horizontalMovementInput, horizontalMaxSpeed);
        float finalVerticalSpeed = CalculateFinalSpeed(currentVerticalSpeed, verticalMovementInput, verticalMaxSpeed);
        
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
