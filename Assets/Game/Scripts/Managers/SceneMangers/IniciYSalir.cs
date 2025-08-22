using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciYSalir : MonoBehaviour
{
    public void Starter()
    {
        SceneManager.LoadScene("ExamenFinal");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
