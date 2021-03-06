﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(7);
    }
}
