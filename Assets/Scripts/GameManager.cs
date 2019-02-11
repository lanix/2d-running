using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public Text textLabel;
    private Vector3 score;


    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.menu;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGameState == GameState.inGame)
        {
            score =  PlayerController.instance.transform.position - PlayerController.instance.startingPosition;
            textLabel.text = score.x.ToString("0");
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
        PlayerController.instance.Restart();
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // Setup unity scene for menu state
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            

        }
        else if (newGameState == GameState.inGame)
        {
            // Setup unity scene for inGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            // Setup unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
           
            
        }

        currentGameState = newGameState;

    }

}
