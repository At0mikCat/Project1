using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TareasUI : MonoBehaviour
{
    [SerializeField] private GameObject Tarea;
    [SerializeField] private Button Salir;





    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Tarea.gameObject.SetActive(true);
            }
        }
    }





    public void Exit()
    {
        Tarea.gameObject.SetActive(false);
    }
}
