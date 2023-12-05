using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    bool staminaOff = false;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Translate(h, 0, v);

        if (Input.GetKey(KeyCode.LeftShift) && !staminaOff)
        {
            Speed = 4f;
            //StaminaBar.fillAmount -= 0.3f * Time.deltaTime;
        }
        else
        {
            Speed = 3.4f;
            //StaminaBar.fillAmount += 0.1f * Time.deltaTime;
        }
    }
}
