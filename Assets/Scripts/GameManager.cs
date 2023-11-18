using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
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

    public GameObject ProtectorDestructableWallLeftRight;

    //TASK2
    public float contadorSnapTask2;

    public GameObject ProtectorDestructableWallCentre;

    //TASK3
    public float contadorSnapTask3;
    public GameObject ProtectorDestructableWallRight;
    public void Count()
    {
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
        if(keys == 3)
        {
            KeysText.color = Color.yellow;
        }
        if(remainingTime > 0)
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
        if(remainingTime < 60)
        {
            Timer.color = Color.red;
        }



        if(count == 4)
        {
            Check1.gameObject.SetActive(true);
            Destroy(ProtectorDestructableWallLeftRight);
        }

        if(contadorSnapTask2 == 5)
        {
            Check2.gameObject.SetActive(true);
            Destroy(ProtectorDestructableWallCentre);
        }

        if(contadorSnapTask3 == 3)
        {
            Check3.gameObject.SetActive(true);
            Destroy(ProtectorDestructableWallRight);
        }

        if(keys == 3)
        {
            Destroy(FinalDoor);
            ESCAPE.text = "Escapa del laberinto antes que sea tarde";
            //destroy door and change the message for ESCAPE;
        }
    }
}
