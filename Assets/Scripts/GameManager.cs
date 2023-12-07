using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TUTORIAL;
    public GameObject Deactivator;
    public GameObject PRISONFATHER;
    public AudioSource Click;
    public Image TutorialBack;
    public GameObject Tarea1;
    public GameObject Tarea2;
    public GameObject Tarea3;

    public float keys;
    public TextMeshProUGUI KeysText;

    public Image Check1;
    public Image Check2;
    public Image Check3;
    public Image Check4;

    public TextMeshProUGUI ESCAPE;
    public GameObject FinalDoor;

    public TextMeshProUGUI Timer;
    public float remainingTime = 0;

    //TASK1
    public float count;

    public AudioSource snap;

    public GameObject ProtectorDestructableWallLeftRight;

    //TASK2
    public float contadorSnapTask2;

    public GameObject ProtectorDestructableWallCentre;

    //TASK3
    public float contadorSnapTask3;
    public GameObject ProtectorDestructableWallRight;

    private void Awake()
    {
        TUTORIAL.text = "¡Bienvenido! Estas escapando de un tronco poseído tras robarte un valioso artefacto, te hare recordar todas tus habilidades antes de escapar de el";
    }

    public void Count()
    {
        snap.Play();
        count++;
    }
    public void CountKey()
    {
        keys++;
    }
    public void Discount()
    {
        count--;
    }

    //TASK 2   
    public void SnapCount()
    {
        contadorSnapTask2++;
    }

    //TASK 3
    public void SnapCountTask3()
    {
        contadorSnapTask3++;
    }

    private void Update()
    {
        KeysText.text = keys.ToString();
        if (keys == 3)
        {
            KeysText.color = Color.yellow;
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            Time.timeScale = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //change color text
        if (remainingTime < 60)
        {
            Timer.color = Color.red;
        }

        if (remainingTime < 294 && Deactivator.GetComponent<DeactivateTutorial>().quierosalirayuaa == false)
        {
            TUTORIAL.text = "¡Bueno pues empecemos! Te mueves con las teclas direccionales, corres con Shift, interactuas con Z y cierras ciertos menús con el Mouse";
        }

        if (remainingTime < 288 && Deactivator.GetComponent<DeactivateTutorial>().quierosalirayuaa == false)
        {
            TUTORIAL.text = "A tu izquierda ves un detector, activan misiones de UI, adelante tienes una puerta rota, que si la tocas se cae y por ultimo a la derecha está una puerta que se abre al recoger una llave, avanza derecho para seguir";
        }
    
        if (Deactivator.GetComponent<DeactivateTutorial>().quierosalirayuaa == true)
        {
            TUTORIAL.text = "¿Asi que quieres salir? Suerte, la necesitarás y recuerda prestar atención al minimapa";
            StartCoroutine(Wait());
        }

        if(count == 4)
        {
            Check1.gameObject.SetActive(true);
            Tarea1.gameObject.SetActive(false);
            Destroy(ProtectorDestructableWallLeftRight);
        }

        if(contadorSnapTask2 == 5)
        {
            Tarea2.gameObject.SetActive(false);
            Check2.gameObject.SetActive(true);
            Destroy(ProtectorDestructableWallCentre);
        }

        if(contadorSnapTask3 == 3)
        {
            Tarea3.gameObject.SetActive(false);
            Check3.gameObject.SetActive(true);
            Destroy(ProtectorDestructableWallRight);
        }

        if(keys == 3)
        {
            Destroy(FinalDoor);
            ESCAPE.text = "Escapa del laberinto antes que sea tarde";
            //destroy door and change the message for ESCAPE;
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3);
            Click.Play();
            TUTORIAL.text = "CORRE, EL MONSTRUO ESTÁ LIBRE";
            Destroy(Deactivator);
            Destroy(PRISONFATHER);
            StartCoroutine(WaitFromWait());
        }

        IEnumerator WaitFromWait()
        {
            yield return new WaitForSeconds(2);
            TutorialBack.gameObject.SetActive(false);
        }
    }
}
