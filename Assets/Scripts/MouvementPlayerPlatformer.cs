using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MouvementPlayerPlatformer : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private Vector2 limiteMin = new(-10f, -6f);
    [SerializeField] private Vector2 limiteMax = new(10f, 6f);

    private Rigidbody2D corps;
    private Animator animator;
    private Vector2 direction;
    private bool commandesActives = true;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!commandesActives)
        {
            direction = Vector2.zero;
            animator.SetBool("EnMouvement", false);
            return;
        }

        direction = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        // Flip du personnage
        if (direction[0] > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction[0] < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // // jump
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     corps.linearVelocity = new Vector2(corps.linearVelocity.x, jumpForce);
        // }

        animator.SetBool("EnMouvement", direction.sqrMagnitude > 0.01f);
    }

    private void FixedUpdate()
    {
        corps.linearVelocity = commandesActives ? direction * vitesse : Vector2.zero;
        LimiterPosition();
    }

    private void LimiterPosition()
    {
        Vector2 position = corps.position;
        position.x = Mathf.Clamp(position.x, limiteMin.x, limiteMax.x);
        position.y = Mathf.Clamp(position.y, limiteMin.y, limiteMax.y);
        corps.position = position;
    }

    public void DesactiverCommandes()
    {
        commandesActives = false;
        direction = Vector2.zero;
        corps.linearVelocity = Vector2.zero;
        animator.SetBool("EnMouvement", false);
    }
}
