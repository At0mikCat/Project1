using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenúInicio : MonoBehaviour
{


    public void PlayGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnButon()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
