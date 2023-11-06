using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject Statues;
    public GameObject GM;
    public GameManager GameManager;

    private void Awake()
    {
        GameManager = GM.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Statue")
        {
            Debug.Log("Hola");
            GameManager.Count();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Statues.transform.Rotate(0, 5, 0);
            }
        }
    }
}
