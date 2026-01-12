using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;

    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioS;
    private SpriteRenderer sprite;

    // Start is called before the f irst frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioS.Stop();  
    }

    // Update is called once per frame
    void Update()
    {
        //move
        float input = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(input * speed * Time.deltaTime, 0);


        transform.Translate(movement);

        if (input == 1) {
            audioS.Play();
            animator.SetBool("walking", true);
            sprite.flipX = false;
        }
        else if (input == -1)
        {
            audioS.Play();
            animator.SetBool("walking", true);
            sprite.flipX = true;
        }
        else
        {
            audioS.Stop();
            animator.SetBool("walking", false);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.AddForce(new Vector2(0, 1) * jumpHeight, ForceMode2D.Impulse);
        }



    }

    bool isGrounded()
    {
        return Physics2D.Raycast(
        origin: transform.position, 
        direction: Vector2.down, 
        distance: 1.9f, 
            layerMask: groundLayer);
    }
}
