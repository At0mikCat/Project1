using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float Rotspeed;
    [SerializeField] private float Speed;

    private Rigidbody Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Rotspeed * Time.deltaTime;
        transform.Rotate(0, h, 0);
        float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Translate(0, 0, v);
    }
}
