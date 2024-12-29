using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Records : MonoBehaviour
{

    [SerializeField] private TMP_Text recordTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void DisplayHighScores()
    {
        Debug.Log("DisplayHighScores called");
        List<Tuple<string, int>> topScores = ScoreController.Instance.GetHighScores(); // Изменено на получение кортежей
        Debug.Log("got scores called");

        // Здесь вы можете отобразить рекорды, например, в UI
        string recordTableContent = "";
        for (int i = 0; i < topScores.Count; i++) // Используем Count вместо size()
        {
            // Изменено для отображения имени и счета
            recordTableContent += (i + 1) + ". " + topScores[i].Item1 + " - " + topScores[i].Item2 + "\n";
            Debug.Log("High Score: " + topScores[i].Item1 + " - " + topScores[i].Item2);
        }

        // Убедитесь, что recordTable инициализирован
        if (recordTable != null && recordTableContent != "")
        {
            recordTable.text = recordTableContent; // Обновляем текст счёта
        }
        else
        {
            recordTable.text = "Пока что пусто..."; // Обновляем текст счёта
        }
    }
}
