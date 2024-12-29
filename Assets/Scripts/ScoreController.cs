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
        // Проверяем, существует ли уже экземпляр HighScoreManager
        if (instance == null)
        {
            Debug.Log("Я создаю instance");
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать при загрузке новой сцены
            LoadHighScores(); // Загружаем рекорды
        }
        // else
        // {
        //     Debug.Log("Я удаляю instance");
        //     Destroy(gameObject); // Уничтожаем дубликат
        // }
    }

    public void AddScore(string name, int newScore)
    {
        // Добавляем новый рекорд
        highScores.Add(new Tuple<string, int>(name, newScore));
        // Сортируем рекорды по убыванию
        highScores.Sort((a, b) => b.Item2.CompareTo(a.Item2)); // Сравниваем по второму элементу (счету)

        // Удаляем лишние рекорды, если их больше, чем topScoresCount
        while (highScores.Count > topScoresCount)
        {
            highScores.RemoveAt(highScores.Count - 1);
            Debug.Log("Удалён рекорд. Теперь их: " + highScores.Count);
        }

        // Сохраняем обновлённый список рекордов
        SaveHighScores();
        Debug.Log("HIGHSCORESMANAGER: я добавил " + newScore + ". Текущие рекорды: " + string.Join(", ", highScores));
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
