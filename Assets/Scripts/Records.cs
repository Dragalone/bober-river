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
        List<Tuple<string, int>> topScores = ScoreController.Instance.GetHighScores(); // �������� �� ��������� ��������
        Debug.Log("got scores called");

        // ����� �� ������ ���������� �������, ��������, � UI
        string recordTableContent = "";
        for (int i = 0; i < topScores.Count; i++) // ���������� Count ������ size()
        {
            // �������� ��� ����������� ����� � �����
            recordTableContent += (i + 1) + ". " + topScores[i].Item1 + " - " + topScores[i].Item2 + "\n";
            Debug.Log("High Score: " + topScores[i].Item1 + " - " + topScores[i].Item2);
        }

        // ���������, ��� recordTable ���������������
        if (recordTable != null && recordTableContent != "")
        {
            recordTable.text = recordTableContent; // ��������� ����� �����
        }
        else
        {
            recordTable.text = "���� ��� �����..."; // ��������� ����� �����
        }
    }
}
