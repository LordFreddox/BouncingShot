using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
}
