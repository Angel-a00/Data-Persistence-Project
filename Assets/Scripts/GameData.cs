using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string PlayerName;

  

    [System.Serializable]
    public class  ScoreEntry
    {
        public string PlayerName;
        public int Score;
    }
    [System.Serializable]
    class ScoreListWrapper
    {
        public List<ScoreEntry> Scores;
    }
    public List<ScoreEntry> TopScores = new List<ScoreEntry>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScores();
     

    }
    public void AddScore(string name, int score)
    {
        ScoreEntry entry = new ScoreEntry
            {
            PlayerName = name,
            Score = score
        };
        TopScores.Add(entry);
        TopScores.Sort((a, b) => b.Score.CompareTo(a.Score));
        if (TopScores.Count > 5)
        {
            TopScores.RemoveAt(5);
        }
        SaveScores();
    }
    void SaveScores()
    {
        ScoreListWrapper wrapper = new ScoreListWrapper ();
        wrapper.Scores = TopScores;
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("TopScores", json);
        PlayerPrefs.Save();
    }
    void LoadScores()   
    {
        if (PlayerPrefs.HasKey("TopScores"))
        {
            string json = PlayerPrefs.GetString("TopScores");
            ScoreListWrapper wrapper = JsonUtility.FromJson<ScoreListWrapper>(json);
            
            if (wrapper != null && wrapper.Scores != null)
            {
                TopScores = wrapper.Scores;
            }
            else
            {
                TopScores = new List<ScoreEntry>();
            }
        }
        else             {
                TopScores = new List<ScoreEntry>();
        }
    }

}
