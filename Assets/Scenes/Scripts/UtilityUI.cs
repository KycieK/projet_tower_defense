using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityUI 
{
    static GameObject _gameOverUI;
    static public bool gameIsOver;


    static public void InitGameOverUI(GameObject gameOverUI)
    {
        _gameOverUI = gameOverUI;
    }

    public static void EndGame(){

        gameIsOver = true;
        _gameOverUI.SetActive(true);

    }

    internal static void InitGameOverUI()
    {
        throw new NotImplementedException();
    }
}
