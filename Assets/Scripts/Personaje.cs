using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float Rotspeed;
    [SerializeField] private float Speed;
    [SerializeField] private float runSpeed;

    public Image StaminaBar;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    bool invincible = false;
    bool staminaOff = false;

    private Rigidbody Rb;

    private void Awake()
    {
        Time.timeScale = 1;
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Rotspeed * Time.deltaTime;
        transform.Rotate(0, h, 0);
        float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Translate(0, 0, v);

        if (Input.GetKey(KeyCode.LeftShift) && !staminaOff)
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            StaminaBar.fillAmount -= 0.3f * Time.deltaTime;
        }
        else
        {
            transform.Translate(0, 0, v);
            StaminaBar.fillAmount += 0.1f * Time.deltaTime;
        }

        if (StaminaBar.fillAmount <= 0)
        {
            staminaOff = true;
            StartCoroutine(Stamina());
        }

        if(invincible)
        {
            StartCoroutine(Invincible());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster") && !invincible)
        {
            invincible = true;
            if (Heart3.gameObject.activeSelf == true)
            {
                Heart3.gameObject.SetActive(false);
            }
            else if (Heart2.gameObject.activeSelf == true)
            {
                Heart2.gameObject.SetActive(false);
            }
            else if (Heart1.gameObject.activeSelf == true)
            {
                Heart1.gameObject.SetActive(false);
                //show death panel
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(3);
        invincible = false;
    }

    IEnumerator Stamina()
    {
        yield return new WaitForSeconds(8);
        staminaOff = false;
    }

}
