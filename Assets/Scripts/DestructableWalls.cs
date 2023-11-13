using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWalls : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            animator.SetTrigger("Destroy");
        }
    }
}
