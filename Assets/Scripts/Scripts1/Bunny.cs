using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    public GameObject Dialogue;

    public GameObject ButtonE;

    private void Update()
    {
        if (ButtonE != null && Input.GetKeyDown(KeyCode.E))
        {
            if (ButtonE.activeSelf)
            {
                Dialogue.SetActive(true);
                Destroy(ButtonE);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ButtonE != null)
        {
            ButtonE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ButtonE != null)
        {
            ButtonE.SetActive(false);
        }
    }
}
