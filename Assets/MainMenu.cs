﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // To load the Game Scene
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
