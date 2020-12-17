using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button botonJugar;
    public Button botonSalir;
    public Text highscoreText;

    private void Awake()
    {
        botonJugar.onClick.AddListener(OnClickJugar);

        botonSalir.onClick.AddListener(OnClickSalir);
        if(PlayerPrefs.GetInt("highscore") != 0)
        {
            highscoreText.text = PlayerPrefs.GetString("bestplayer") + ":    " + PlayerPrefs.GetInt("highscore");
        }
        
    }

    private void OnClickJugar()
    {
        AppLogic.Instance.LoadGame();
    }
    private void OnClickSalir()
    {
        PlayerPrefs.Save();
        AppLogic.Instance.Salir();
    }


}
