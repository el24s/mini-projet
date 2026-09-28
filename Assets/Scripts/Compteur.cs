using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Compteur : MonoBehaviour
{
    public TMP_Text timeText;
    public bool timeIsRunning = true;
    public float timeRemaining = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds );
    }
}
