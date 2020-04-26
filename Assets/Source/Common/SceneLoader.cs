using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentSceneIndex;

    void Awake()
    {
        var instance = FindObjectOfType<SceneLoader>();

        if(instance != this)
            Destroy(instance.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadNext()
    {
        currentSceneIndex++;

        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings)
            currentSceneIndex = 0;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
