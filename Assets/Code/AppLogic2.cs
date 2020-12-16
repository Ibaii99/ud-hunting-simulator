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
        // cambiar a SceneFacil
        SceneManager.LoadScene("SampleScene");
    }
    public void CargarJuegoIntermedio()
    {
        // cambiar a SceneIntermedio
        //SceneManager.LoadScene("SampleSceneInter");
    }
    public void CargarJuegoDificil()
    {
        // cambiar a SceneDificil
        //SceneManager.LoadScene("SampleSceneDif");
    }

}
