using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject GM;
    public GameManager GameManager;

    public Animator doorAnimator;

    private void Awake()
    {
        GameManager = GM.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            GameManager.CountKey();
            doorAnimator.SetTrigger("Open");
            Destroy(gameObject);
        }
    }
}
