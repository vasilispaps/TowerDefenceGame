using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;
    

    public GameObject gameOverUI;
    public GameObject winGameUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Player.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        GameIsOver = true;
        winGameUI.SetActive(true);
    }

}