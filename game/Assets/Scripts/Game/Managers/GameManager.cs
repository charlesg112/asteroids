using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static Vector2 GetPlayerPosition()
    {
        GameObject player = GameObject.Find("Player");
        if (player) return new Vector2(player.transform.position.x, player.transform.position.y);
        else throw new PlayerNotFoundException("GetPlayerPosition");
    }
}
