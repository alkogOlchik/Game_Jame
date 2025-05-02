using UnityEngine;

public class ShakingCube : MonoBehaviour
{
    public float floatHeight = 0.1f; 
    public float floatWidth = 0.1f;
    public float floatSpeed = 5f; 
    public float shakeDuration = 1f;
    public float posX;
    public GameObject platformPrefab;

    public GameObject Player;
    private Vector3 startPosition;
    private bool isShaking;
    private bool hasSpawned = false; // Добавляем флаг
    private Rigidbody2D rb;
    private float shakeTimer;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        isShaking = false;
        if (rb != null)
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void Update()
    {
        if (Player.transform.position.x >= posX && !isShaking && Player.transform.position.y < -3f)
        {
            isShaking = true;
            shakeTimer = shakeDuration;
            Invoke("DestroyAndSpawn", 1f); // Запланируем создание нового объекта
        }
            
        if (isShaking)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            float newX = startPosition.x + Mathf.Cos(Time.time * floatSpeed) * floatWidth;
            transform.position = new Vector3(newX, newY, startPosition.z);
        }
    }

    void DestroyAndSpawn()
    {
        if (!hasSpawned)
        {
            SpawnFallingPlatform();
            hasSpawned = true;
            Destroy(gameObject);
        }
    }

    void SpawnFallingPlatform()
    {
        Instantiate(platformPrefab, startPosition, Quaternion.identity);
    }
}