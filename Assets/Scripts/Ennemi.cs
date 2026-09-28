using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float playerDamage = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerDamage > 50)
            {
                Debug.Log("Player lost all his lives!");
                
            }
            Debug.Log("Player hit enemy!");
            playerDamage -= 10;
            
        }
    }
}