using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeStart;
    public TextMeshProUGUI textTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textTimer.SetText("Время: " + timeStart.ToString("F2"));
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        textTimer.SetText("Время: " + timeStart.ToString("F2"));
    }
}
