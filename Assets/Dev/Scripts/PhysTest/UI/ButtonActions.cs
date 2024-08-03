using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
