using UnityEngine;

public class Collecteur : MonoBehaviour
{
    [SerializeField] private int objectif = 3;
    [SerializeField] private GameObject porteSortie;

    private int crystalCollectees = 0;

    private void Start()
    {
        // valider la référence, puis cacher la porte au démarrage.
        porteSortie.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        // ignorer les objets qui ne sont pas des batteries.
        if (!autre.CompareTag("Crystal"))
        {
            return;
        }

        // ramasser la batterie et mettre le compteur à jour.
        crystalCollectees++;
        Debug.Log($"Crystal : {crystalCollectees}/{objectif}");
        Destroy(autre.gameObject);


        // déverrouiller la porte lorsque l'objectif est atteint.
        if (porteSortie == null)
        {
            Debug.LogError("La porte de sortie n'est pas assignée.");
            return;
        }

        if (crystalCollectees >= objectif)
        {
            porteSortie.SetActive(true);
            Debug.Log("PORTE DÉVERROUILLÉE !");
            
        }
        
    }

    /*
     * BANQUE DE LIGNES — GROUPE B
     * Certaines lignes doivent être placées à l'intérieur d'un if.
     * Ajoutez les accolades et l'indentation nécessaires.
     *
     * 
     * 
     * 
     * 
     * 

     * 

     * 
     
     * 
     * 
     * 
     * 
     * 
     */
}
