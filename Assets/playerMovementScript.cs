using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool grounded;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 55f, LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, Vector2.down, Color.red ,5f );
        //move
        Vector2 input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: 0);

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }
        transform.position = (Vector2) transform.position 
            + input
            * Time.deltaTime
            * speed;
        //jump
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            rb.AddForce(new Vector3(x: 0, y: jumpHeight));
            grounded = false;

        }

        Debug.Log(grounded.ToString());


    }
}
