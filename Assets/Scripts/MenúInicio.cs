using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenúInicio : MonoBehaviour
{
    [SerializeField] GameObject PanelOpciones;


    public void PlayGameButton()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
