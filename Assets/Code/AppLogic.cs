using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppLogic : MonoBehaviour
{

    private static AppLogic instance;

    public static AppLogic Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("ElegirDificultad");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
