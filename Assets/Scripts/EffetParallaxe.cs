 using UnityEngine;

public class EffetParallaxe : MonoBehaviour
{
    [Header("Caméra")]
    [SerializeField] private Transform cameraCible;

    [Header("Suivi de la caméra")]
    [SerializeField, Range(0f, 1f)] private float suiviHorizontal = 0.85f;
    [SerializeField, Range(0f, 1f)] private float suiviVertical = 0.90f;

    [Header("Déplacement automatique très lent")]
    [SerializeField] private Vector2 vitesseAutomatique = new(0.01f, 0f);

    private Vector3 positionInitiale;
    private Vector3 positionCameraInitiale;
    private Vector2 decalageAutomatique;

    private void Start()
    {
        // TODO 1 : mémoriser la position initiale de cette couche.
        positionInitiale = transform.position;
        
        // TODO 2 : trouver automatiquement la caméra si elle n'est pas assignée.
        if (cameraCible == null && Camera.main != null) {
            cameraCible = Camera.main.transform;
        }
        // TODO 3 : mémoriser la position initiale de la caméra.
        positionCameraInitiale = cameraCible.position;
    }

    private void LateUpdate()
    {
        // TODO 4 : arrêter la méthode si aucune caméra n'est disponible.
        if (cameraCible == null) {
            return;    
        }
        
        // TODO 5 : calculer le déplacement de la caméra.
        if (cameraCible != null) {
            Vector3 mouvementCamera = cameraCible.position - positionCameraInitiale;    
         
        // TODO 6 : mettre à jour le déplacement automatique.
        decalageAutomatique += vitesseAutomatique * Time.deltaTime;
        // TODO 7 : calculer et appliquer la nouvelle position de la couche.
        transform.position = new Vector3(
            positionInitiale.y + mouvementCamera.y * suiviVertical + decalageAutomatique.y,
            positionInitiale.x + mouvementCamera.x * suiviHorizontal + decalageAutomatique.x,
            positionInitiale.z 
        );
        }
    }

    /*
     * BANQUE DE LIGNES — À REPLACER ET À INDENTER
     *
     * Toutes les instructions nécessaires sont présentes.
     * Les accolades des conditions ne sont pas fournies.
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
     * 
     * 
     */
}
