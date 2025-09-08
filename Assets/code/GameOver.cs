using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

   // public Text roundsText;

    //void OnEnable()
    //{
    //    roundsText.text = Player.Rounds.ToString();
    //}

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Go to menu.");
    }
}