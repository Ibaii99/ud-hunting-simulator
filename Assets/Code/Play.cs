using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button botonJugar;
    public Button botonSalir;

    private void Awake()
    {
        botonJugar.onClick.AddListener(OnClickJugar);

        botonSalir.onClick.AddListener(OnClickSalir);
    }

    private void OnClickJugar()
    {
        AppLogic.Instance.LoadGame();
    }
    private void OnClickSalir()
    {
        AppLogic.Instance.Salir();
    }


}
