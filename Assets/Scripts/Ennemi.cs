using UnityEngine;

public class Ennemi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a été touché par l'ennemi");

            HeartSystem heartSystem = FindFirstObjectByType<HeartSystem>();

            if (heartSystem != null)
            {
                heartSystem.TakeDamage(1);
                
                
            }
            else
            {
                Debug.Log("Aucun HeartSystem trouvé dans la scène!");
               
            }
            
        }
    }
}