using System;
using UnityEngine;

public class ShowButtonHint : MonoBehaviour
{
    public GameObject buttonHint;
    public GameObject OpenedDoor;

    private void Update()
    {
        if(buttonHint.activeSelf && Input.GetKeyDown(KeyCode.E))
            OpenedDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonHint.SetActive(false);
        }
    }
}