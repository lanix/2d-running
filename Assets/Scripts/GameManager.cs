using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}


public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.menu;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }

    public void Awake()
    {
        instance = this;
    }

    // Called to start the game
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    // Called when player dies
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    // Called when player decide to go back to the menu
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // Setup unity scene for menu state
        }
        else if (newGameState == GameState.inGame)
        {
            // Setup unity scene for inGame state
        }
        else if (newGameState == GameState.gameOver)
        {
            // Setup unity scene for gameOver state
        }

        currentGameState = newGameState;

    }

}
