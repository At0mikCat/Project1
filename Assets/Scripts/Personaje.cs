using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float RotSpeed;

    public Image StaminaBar;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    bool invincible = false;
    bool staminaOff = false;

    private Rigidbody Rb;
    private Animator animator;

    public GameObject A;

    private void Awake()
    {
        Time.timeScale = 1;
        Rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        transform.Rotate(0, h, 0);
        transform.Translate(0, 0, v);


        if (h != 0 || v != 0)
        {
            animator.SetBool("Idle?", false);
        }
        else
        {
            animator.SetBool("Idle?", true);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !staminaOff)
        {
            animator.SetBool("isRunning", true);
            Speed = 4f;
            StaminaBar.fillAmount -= 0.3f * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isRunning", false);
            Speed = 3.4f;
            StaminaBar.fillAmount += 0.1f * Time.deltaTime;
        }

        if (StaminaBar.fillAmount <= 0)
        {
            staminaOff = true;
            StartCoroutine(Stamina());
        }

        if(invincible)
        {
            A.SetActive(false);
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
        yield return new WaitForSeconds(2);
        invincible = false;
        A.SetActive(true);
    }

    IEnumerator Stamina()
    {
        yield return new WaitForSeconds(8);
        staminaOff = false;
    }

}
