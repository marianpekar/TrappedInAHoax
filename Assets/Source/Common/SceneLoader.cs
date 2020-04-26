using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentSceneIndex;

    void Awake()
    {
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
            SceneManager.LoadScene(currentSceneIndex);
    }
}
