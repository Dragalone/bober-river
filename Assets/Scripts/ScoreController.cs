using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const string HighScoresKey = "HighScores";
    private List<Tuple<string, int>> highScores = new List<Tuple<string, int>>();
    private static ScoreController instance;
    private int topScoresCount = 5;

    public static ScoreController Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("HighScoreManager is null! Make sure it is in the scene.");
            }
            return instance;
        }
    }

    void Awake()
    {
        // ���������, ���������� �� ��� ��������� HighScoreManager
        if (instance == null)
        {
            Debug.Log("� ������ instance");
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ��� �������� ����� �����
            LoadHighScores(); // ��������� �������
        }
        // else
        // {
        //     Debug.Log("� ������ instance");
        //     Destroy(gameObject); // ���������� ��������
        // }
    }

    public void AddScore(string name, int newScore)
    {
        // ��������� ����� ������
        highScores.Add(new Tuple<string, int>(name, newScore));
        // ��������� ������� �� ��������
        highScores.Sort((a, b) => b.Item2.CompareTo(a.Item2)); // ���������� �� ������� �������� (�����)

        // ������� ������ �������, ���� �� ������, ��� topScoresCount
        while (highScores.Count > topScoresCount)
        {
            highScores.RemoveAt(highScores.Count - 1);
            Debug.Log("����� ������. ������ ��: " + highScores.Count);
        }

        // ��������� ���������� ������ ��������
        SaveHighScores();
        Debug.Log("HIGHSCORESMANAGER: � ������� " + newScore + ". ������� �������: " + string.Join(", ", highScores));
    }

    private void SaveHighScores()
    {
        List<string> scoresToSave = new List<string>();
        foreach (var score in highScores)
        {
            scoresToSave.Add($"{score.Item1}:{score.Item2}");
        }
        PlayerPrefs.SetString(HighScoresKey, string.Join(",", scoresToSave));
        PlayerPrefs.Save();
    }

    private void LoadHighScores()
    {
        if (PlayerPrefs.HasKey(HighScoresKey))
        {
            string[] scores = PlayerPrefs.GetString(HighScoresKey).Split(',');
            highScores.Clear();
            foreach (string score in scores)
            {
                string[] parts = score.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int result))
                {
                    highScores.Add(new Tuple<string, int>(parts[0], result));
                }
            }
        }
        Debug.Log("LoadHighScores");
    }

    public List<Tuple<string, int>> GetHighScores()
    {
        return new List<Tuple<string, int>>(highScores);
    }
}
