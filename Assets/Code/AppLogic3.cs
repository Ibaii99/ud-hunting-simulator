using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppLogic3 : MonoBehaviour
{
    public Text texto;
    public Button aceptar;
    public Text jugador;
    int playerScore;
    int highScore;
    string bestPlayer;
    void OnEnable()
    {
        playerScore = PlayerPrefs.GetInt("score");

        texto.text = playerScore.ToString();
        print("Ha llegado");
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        aceptar.onClick.AddListener(CargarMenu);
    }


    public void CargarMenu()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        bestPlayer = PlayerPrefs.GetString("bestplayer", "Anónimo");
        print(highScore + "   " + playerScore);
        if(jugador.text.Length == 0)
        {
            jugador.text = "Anónimo";
        }
        if (playerScore >= highScore)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
            PlayerPrefs.SetString("bestplayer", jugador.text);

        }
            SceneManager.LoadScene("MainScene");
    }

}
