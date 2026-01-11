using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumableScript : MonoBehaviour
{
    private GameObject Vacuum;
    private bool isBeingVacuumed;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float vacuumSpeed;
    [SerializeField] int id;
    Rigidbody2D rb;
    public bool IsBeingVacuumed { get => isBeingVacuumed; set => isBeingVacuumed = value; }
    public int Id { get => id; set => id = value; }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vacuum = GameObject.Find("Vacuum");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingVacuumed) {
            spriteRenderer.color = Color.cyan;
            transform.position = Vector2.Lerp(transform.position, Vacuum.transform.position, 1f * vacuumSpeed * Time.deltaTime);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
        else
        {
            spriteRenderer.color = Color.white;
            rb.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}
