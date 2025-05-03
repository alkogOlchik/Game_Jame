using UnityEngine;
using UnityEngine.UI;

public class ShowButtonHint : MonoBehaviour
{
    public GameObject buttonHint;
    public GameObject OpenedDoor;
    public GameObject KOLOBOK;
    private Transform kolobokTransform;
    public GameObject keys;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public GameObject Player;

    private bool triggerKolobokRespawn;
    private Vector3 newPosition;

    private void Start()
    {
        kolobokTransform = KOLOBOK.transform;
        triggerKolobokRespawn = false;
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && !Dialogue1.activeSelf)
        {
            Destroy(keys);
        }
        if (Input.GetKeyDown(KeyCode.E) && buttonHint != null)
        {
            if (buttonHint.activeSelf)
            {
                OpenedDoor.SetActive(true);
                KOLOBOK.SetActive(true);
                Dialogue2.SetActive(true);
                Destroy(buttonHint);
            }
            
        }   

        if (KOLOBOK.activeSelf)
        {
            newPosition = kolobokTransform.position;
            newPosition.x += 3f * Time.deltaTime;
            kolobokTransform.position = newPosition;
        }

        if (Player.transform.position.x >= 60f && !triggerKolobokRespawn)
        {
            triggerKolobokRespawn = true;
            KOLOBOK.transform.position = new Vector3(64f, newPosition.y, newPosition.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buttonHint != null)
        {
            buttonHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buttonHint != null)
        {
            buttonHint.SetActive(false);
        }
    }
}