using System.Collections.Generic;
using UnityEngine;
 
namespace ExempleFondInfini
{
    // Objet racine sans rotation, échelle (1,1,1). Caméra orthographique non tournée.
    [DefaultExecutionOrder(100)]
    public class FondInfini : MonoBehaviour
    {
        public Camera cameraCible;
        public SpriteRenderer panneauModele;
        [Range(0f, 1f)] public float parallaxe = 0.25f;
        readonly List<SpriteRenderer> panneaux = new List<SpriteRenderer>();
        float largeur, origineX, cameraDepartX, centreLocalX;
        Vector3 positionModele;
        int nombre;
 
        void Start()
        {
            if (!cameraCible) cameraCible = Camera.main;
            if (!cameraCible || !cameraCible.orthographic || !panneauModele || !panneauModele.sprite)
            {
                Debug.LogError("FondInfini : assigner une caméra orthographique et un panneau avec sprite.", this);
                enabled = false;
                return;
            }
            largeur = panneauModele.bounds.size.x;
            if (largeur <= 0.0001f) { enabled = false; return; }
            positionModele = panneauModele.transform.position;
            origineX = panneauModele.bounds.center.x;
            centreLocalX = origineX - positionModele.x;
            cameraDepartX = cameraCible.transform.position.x;
            panneaux.Add(panneauModele);
            Actualiser();
        }
 
        void LateUpdate() { Actualiser(); }
 
        void Actualiser()
        {
            // Assez de panneaux pour toute la largeur de l'écran + marge des deux côtés.
            float demiVue = cameraCible.orthographicSize * cameraCible.aspect;
            int requis = Mathf.CeilToInt(2f * demiVue / largeur) + 3;
            while (panneaux.Count < requis)
            {
                SpriteRenderer copie = Instantiate(panneauModele, panneauModele.transform.parent);
                copie.name = "Panneau recycle " + panneaux.Count;
                panneaux.Add(copie);
            }
            nombre = panneaux.Count;
            // Le décalage suit partiellement la caméra : 0 = décor fixe dans le monde.
            float decalage = (cameraCible.transform.position.x - cameraDepartX) * parallaxe;
            float origine = origineX + decalage;
            int premier = Mathf.FloorToInt((cameraCible.transform.position.x - demiVue - origine) / largeur);
            for (int i = 0; i < nombre; i++)
            {
                // Modulo positif : même objet conservé pour chaque panneau visible.
                int indice = premier + i;
                int emplacement = ((indice % nombre) + nombre) % nombre;
                Vector3 p = positionModele;
                p.x = origine + indice * largeur - centreLocalX;
                panneaux[emplacement].transform.position = p;
            }
        }
    }
}
 