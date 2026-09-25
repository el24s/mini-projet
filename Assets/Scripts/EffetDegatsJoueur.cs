using System.Collections;
using UnityEngine;

public class EffetDegatsJoueur : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private SpriteRenderer renduPlayer;

    [Header("Interface")]
    [SerializeField]
    private CanvasGroup flashEcran;

    [Header("Animation")]
    [SerializeField]
    private Color couleurDegat = Color.red;

    [SerializeField, Min(0.1f)]
    private float dureeEffet = 0.45f;

    [SerializeField, Min(1)]
    private int nombreClignotements = 3;

    [SerializeField, Min(1f)]
    private float agrandissement = 1.12f;

    private Color couleurInitiale;
    private Vector3 echelleInitiale;
    private Coroutine effetEnCours;

    private Animator animator;

    private void Awake()
    {
        if (renduPlayer == null)
        {
            renduPlayer = GetComponent<SpriteRenderer>();
        }

        if (renduPlayer != null)
        {
            couleurInitiale = renduPlayer.color;
        }

        echelleInitiale = transform.localScale;

        if (flashEcran != null)
        {
            flashEcran.alpha = 0f;
        }

        animator = GetComponent<Animator>();
    }

    public void DeclencherEffet()
    {
        if (effetEnCours != null)
        {
            StopCoroutine(effetEnCours);
        }

        effetEnCours = StartCoroutine(JouerEffetDegats());
    }

    private IEnumerator JouerEffetDegats()
    {
        float dureeEtape =
            dureeEffet / (nombreClignotements * 2f);

        transform.localScale =
            echelleInitiale * agrandissement;

        for (int i = 0; i < nombreClignotements; i++)
        {
            if (renduPlayer != null)
            {
                renduPlayer.color = couleurDegat;
            }

            if (flashEcran != null)
            {
                flashEcran.alpha = 0.55f;
            }

            yield return new WaitForSeconds(dureeEtape);

            if (renduPlayer != null)
            {
                renduPlayer.color = couleurInitiale;
            }

            if (flashEcran != null)
            {
                flashEcran.alpha = 0f;
            }

            yield return new WaitForSeconds(dureeEtape);
        }

        if (renduPlayer != null)
        {
            renduPlayer.color = couleurInitiale;
        }

        if (flashEcran != null)
        {
            flashEcran.alpha = 0f;
        }

        transform.localScale = echelleInitiale;
        effetEnCours = null;
    }

    private void OnDisable()
    {
        if (renduPlayer != null)
        {
            renduPlayer.color = couleurInitiale;
        }

        if (flashEcran != null)
        {
            flashEcran.alpha = 0f;
        }

        transform.localScale = echelleInitiale;
    }

    // private IEnumerator DeclencherAnimationDegats

    // collision avec ennemi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            DeclencherEffet();
            

            if ( animator != null)
            {
                animator.SetBool("EnAttaque", collision.gameObject.CompareTag("Ennemi"));    
            }

            if (GestionJeu.Instance != null)
            {
                GestionJeu.Instance.PerdreVie();
            }

            EffetAttaqueEnnemi effetEnnemi = collision.gameObject.GetComponent<EffetAttaqueEnnemi>();

            if ( effetEnnemi != null)
            {
                effetEnnemi.Declencher();
            }
        }   
    }
}