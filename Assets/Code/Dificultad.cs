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
        AppLogic2.Instance.CargarJuegoFacil();
    }
    private void OnClickIntermedio()
    {
        AppLogic2.Instance.CargarJuegoIntermedio();
    }
    private void OnClickDificil()
    {
        AppLogic2.Instance.CargarJuegoDificil();
    }


}
