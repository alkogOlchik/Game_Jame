using UnityEngine;
using UnityEngine.SceneManagement;

public class SmoothNoPhysicsMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Вынесено в публичную переменную
    public GameObject Dialogue;
    private SpriteRenderer sprite;
    private Animator animator;
    private Vector3 moveInput;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Dialogue.activeSelf)
        {
            moveInput = new Vector3(
                        Input.GetAxisRaw("Horizontal"),
                        Input.GetAxisRaw("Vertical"),
                        0
                    ).normalized;
            
            if (Mathf.Abs(moveInput.x) > 0.1f)
            {
                sprite.flipX = moveInput.x > 0.0f;
            }
            
            animator.SetBool("AD", Mathf.Abs(moveInput.x) > 0.1f);
            animator.SetBool("S", moveInput.y < -0.1f);
            animator.SetBool("W", moveInput.y > 0.1f);
        }
        

        
    }

    void FixedUpdate()
    {
        transform.position += moveInput * moveSpeed * Time.fixedDeltaTime;
    }
}