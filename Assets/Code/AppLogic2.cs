using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppLogic2 : MonoBehaviour
{

    private static AppLogic2 instance;

    public static AppLogic2 Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void CargarJuegoFacil()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void CargarJuegoIntermedio()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void CargarJuegoDificil()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
