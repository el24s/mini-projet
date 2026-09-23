using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteSortie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        // ignorer tout objet qui n'est pas le joueur.
        if (!autre.CompareTag("Player"))
        {
            return;
        }

        // annoncer la réussite et faire disparaître le joueur.
        Debug.Log(" Apparition dans la forêt enchantée!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }

    /*
     * BANQUE DE LIGNES — GROUPE B
     * Replacez les lignes, puis ajoutez les accolades manquantes.
     *
     * 
     * 
     * 
     * 
     */
}
