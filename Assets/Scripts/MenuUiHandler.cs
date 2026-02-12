using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInput;
    public void StartGame()
    {
        if (NameInput == null)
        {
            Debug.LogError("NameInput es NULL");
            return;
        }

        if (GameData.Instance == null)
        {
            Debug.LogError("GameData.Instance es NULL");
            return;
        }

        Debug.Log("Todo OK, nombre: " + NameInput.text);

        GameData.Instance.PlayerName = NameInput.text;
        SceneManager.LoadScene("main");

    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
   
}
