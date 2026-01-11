using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BackpackScript : MonoBehaviour
{
    private Hashtable table;
    private VacuumScript vacuumScript;

    void Start()
    {
        table = new Hashtable();
        vacuumScript = GetComponentInParent<VacuumScript>();
    }

    // Update is called once per frame
    void Update()

    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (vacuumScript.Vacuuming)
        {
            try
            {
                VacuumableScript vs = collision.GetComponent<VacuumableScript>();
                if (table.Count < 4)
                {
                    if (table.ContainsKey(vs.Id))
                    {
                        table[vs.Id] = (int)table[vs.Id] + 1;
                        Debug.Log(table[vs.Id]);
                    }
                    else
                    {
                        table.Add(vs.Id, 1);
                        Debug.Log(table[vs.Id]);
                    }
                    Destroy(vs.gameObject);
                }

            }
            catch (Exception) { }
        }
    }

}
