using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PLayer_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 7f;

    public GameObject Dialogue1;
    public GameObject Dialogue2;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (!Dialogue1.activeSelf && !Dialogue2.activeSelf)
        {
            if (Input.GetButton("Horizontal"))
            {
                Run();
            }
            
            if (Input.GetButtonDown("Jump"))
                Jump();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.enabled = false;
                animator.enabled = true;
                animator.SetTrigger("jump");
            }
            bool isWalking = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
            animator.SetBool("walking", isWalking);
            if (transform.position.x >= 75f)
            {
                SceneManager.LoadScene("SecondLocation");
            }  
        }

    }
    
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position+dir, speed*Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
    }



    
}