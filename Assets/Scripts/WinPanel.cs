using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Niveau1");
    }

}
