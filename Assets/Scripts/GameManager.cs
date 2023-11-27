using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance { get; private set; }
    public GameObject gameOverUI;

    void Start() 
    {
        Instance = this;
        UtilityUI.InitGameOverUI(gameOverUI);
        UtilityUI.gameIsOver = false;
    } 

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            UtilityUI.EndGame();
        }
    }

}
