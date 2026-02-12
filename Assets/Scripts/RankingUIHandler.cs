using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RankingUIHandler : MonoBehaviour
{
    public TextMeshProUGUI[] ScoreTexts;

    void Start()
    {
        DisplayScores();
    }

    void DisplayScores()
    {
        var scores = GameData.Instance.TopScores;

        for (int i = 0; i < ScoreTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                ScoreTexts[i].text =
                    $"{i + 1}. {scores[i].PlayerName} - {scores[i].Score}";
            }
            else
            {
                ScoreTexts[i].text = $"{i + 1}. ---";
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
