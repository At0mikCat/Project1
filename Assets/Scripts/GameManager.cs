using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float contadorSnapTask2;
    float contadorSnapTask3;
    //TASK1
    public float count;

    public GameObject ProtectorDestructableWallLeftRight;

    // Crear variable de la muralla de la tarea 2

    public void Count()
    {
        count++;
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


    //crear if destruir muralla task2

    private void Update()
    {
        if(count == 4)
        {
            Destroy(ProtectorDestructableWallLeftRight);
        }

        //TASK2
    }
}
