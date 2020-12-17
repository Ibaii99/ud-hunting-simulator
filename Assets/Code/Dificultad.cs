using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificultad : MonoBehaviour
{
    public Button botonFacil;
    public Button botonIntermedio;
    public Button botonDificil;

    private void Awake()
    {
        botonFacil.onClick.AddListener(OnClickFacil);

        botonFacil.onClick.AddListener(OnClickIntermedio);

        botonFacil.onClick.AddListener(OnClickDificil);

    }

    private void OnClickFacil()
    {
	Debug.Log("Fácil");
        AppLogic2.Instance.CargarJuegoFacil();
    }
    private void OnClickIntermedio()
    {
	Debug.Log("Inter");
        AppLogic2.Instance.CargarJuegoIntermedio();
    }
    private void OnClickDificil()
    {
	Debug.Log("Dif");
        AppLogic2.Instance.CargarJuegoDificil();
    }


}
