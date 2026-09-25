using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteSortieFinale : MonoBehaviour
{
    public GameObject winManager;

    private void OnTriggerEnter2D(Collider2D autre)
    {
        // ignorer tout objet qui n'est pas le joueur.
        if (!autre.CompareTag("Player"))
        {
            return;
        }

        // annoncer la réussite et faire disparaître le joueur.
        Debug.Log("SUCCESS tu as réussi le jeu");
        winManager.SetActive(true);

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
