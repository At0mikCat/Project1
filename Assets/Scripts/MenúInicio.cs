using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenúInicio : MonoBehaviour
{
    [SerializeField] GameObject PanelOpciones;


    public void PlayGameButton(){
        SceneManager.LoadScene("Juego");
    }
    public void OptionsButton(){
    
        PanelOpciones.SetActive(true);
    }
    public void QuitButtonOptions() {
        PanelOpciones.SetActive(false);
    }
    
    public void ExitButton(){
        Application.Quit();
    }
}
