using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TASK1
    public float count;

    public GameObject ProtectorDestructableWallLeftRight;

    public void Count()
    {
        count++;
    }
    public void Discount()
    {
        count--;
    }

    private void Update()
    {
        if(count == 4)
        {
            Destroy(ProtectorDestructableWallLeftRight);
        }
    }
}
