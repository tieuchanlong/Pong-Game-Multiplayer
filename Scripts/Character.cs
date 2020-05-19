using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private string name;

    // Using Properties
    public string Name // this properties help u with Abstraction, so you can either get or set variable
    {
        get
        {
            // Some other codes if you want
            return name;
        }
        set
        {
            // Some other codes
            name = value;
        }
    }

    // Auto implemented Properties will help auto get and set
    //public string Name1 { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
    }

    public virtual void MoveToPoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Move the character
            agent.SetDestination(hit.point);
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectEntityPool.SharedInstance.GetPooledObject();

        if (bullet != null)
        {
            // do something with it
        }
    }
}
