using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumScript : MonoBehaviour
{
    private bool vacuuming;
    public bool Vacuuming { get => vacuuming; set => vacuuming = value; }

    // Start is called before the first frame update
    void Start()
    {

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (vacuuming) {
            vacuum(collision);
        }
        else
        {
            noVacuum(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        noVacuum(other);
    }




    void vacuum(Collider2D collision)
    {
        try
        {
            VacuumableScript vs = collision.GetComponent<VacuumableScript>();
            vs.IsBeingVacuumed = true;
        }
        catch (Exception){}
    }
    void noVacuum(Collider2D collision)
    {
        try
        {
            VacuumableScript vs = collision.GetComponent<VacuumableScript>();
            vs.IsBeingVacuumed = false;
        }
        catch (Exception){}
    }

}
