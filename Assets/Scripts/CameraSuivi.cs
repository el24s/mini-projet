using UnityEngine;

public class CameraSuivi : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;

        }
    }
}
