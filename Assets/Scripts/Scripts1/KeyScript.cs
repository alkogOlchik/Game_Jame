using UnityEngine;

public class ShowButtonHint : MonoBehaviour
{
    public GameObject buttonHint;
    public GameObject OpenedDoor;
    public GameObject KOLOBOK;
    private Transform kolobokTransform;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;

    private void Start()
    {
        kolobokTransform = KOLOBOK.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
            key4.SetActive(false);
        }
        if (buttonHint.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            OpenedDoor.SetActive(true);
            KOLOBOK.SetActive(true);
        }   

        if (KOLOBOK.activeSelf)
        {
            Vector3 newPosition = kolobokTransform.position;
            newPosition.x += 5f * Time.deltaTime;
            kolobokTransform.position = newPosition;
        }
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