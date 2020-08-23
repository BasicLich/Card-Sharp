using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        DialogueManager.dialogueIsActive = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("SceneToLoad", "StartScene"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
