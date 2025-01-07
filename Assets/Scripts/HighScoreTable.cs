using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private List<Transform> highscoreEntryTransformList;

/*    private static HighScoreTable instance;
    public static HighScoreTable Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("HighScoreManager is null! Make sure it is in the scene.");
            }
            return instance;
        }
    }*/

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

       // AddHighscoreEntry(9999999, "Capy");
/*        AddHighscoreEntry(77777, "NotCapy");
        AddHighscoreEntry(3333, "Василий");
        AddHighscoreEntry(2222, "Иван");
        AddHighscoreEntry(1111, "Полина");*/

        string jsonString = PlayerPrefs.GetString("highScoreTable");

        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Sort((e1, e2) => e2.score.CompareTo(e1.score));

        highscoreEntryTransformList = new List<Transform>();
        int entryCount = highscores.highscoreEntryList.Count <= 10 ? highscores.highscoreEntryList.Count : 10;
        for(int i = 0; i < entryCount; i++)
        {
            CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
        }

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 70f;

            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;

            int score = highscoreEntry.score;

            string name = highscoreEntry.name;

            entryTransform.Find("PosText").GetComponent<TextMeshProUGUI>().text = rank.ToString();
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;

        switch (rank)
        {
            default:
                entryTransform.Find("Troph").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("Troph").GetComponent<Image>().color = new Color(255f / 255.0f, 215f / 255.0f, 0f / 255.0f, 1);
                break;
            case 2:
                entryTransform.Find("Troph").GetComponent<Image>().color = new Color(128f / 255.0f, 128f / 255.0f, 128f / 255.0f, 1);
                break;
            case 3:
                entryTransform.Find("Troph").GetComponent<Image>().color = new Color(150f / 255.0f, 116f / 255.0f, 68f / 255.0f, 1);
                break;
        }

            transformList.Add(entryTransform);
        
    }

    public void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{ score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if(highscores == null ) {
            highscores = new Highscores();
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }
        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
