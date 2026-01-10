using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumScript : MonoBehaviour
{
    private bool vacuuming;
    private Collider2D col;
    public bool Vacuuming { get => vacuuming; set => vacuuming = value; }

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            vacuuming = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            vacuuming = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("asd");   
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("jó");
    }
}
