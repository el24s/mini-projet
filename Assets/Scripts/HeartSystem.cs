using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life = 3;
    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int d)
    {
        life -= d;

        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if( life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if( life < 3)
        {
            Destroy(hearts[2].gameObject);
        }

        if (life <= 0)
        {
            Debug.Log("Player a perdue toutes ses vies!");
        }

    }
}
