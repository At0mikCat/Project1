using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivateTutorial : MonoBehaviour
{
    public TextMeshProUGUI TUTORIAL;
    public bool quierosalirayuaa = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            quierosalirayuaa = true;
        }
    }
}
