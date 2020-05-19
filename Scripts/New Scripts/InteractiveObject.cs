using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    protected float interactiveRange = 5f;
    public LayerMask interactiveObjects;
    public float interactTime = 5f;
    protected bool interacting = true;
    protected float interactCount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInteract();
    }

    protected virtual void PlayerInteract()
    {
        Collider[] affectingObj = Physics.OverlapSphere(transform.position, interactiveRange, interactiveObjects);

        if (affectingObj.Length > 0)
        {
            if (Input.GetButton("Interact") && interacting == true)
            {
                interactCount += 0.1f;
                if (interactCount >= interactTime)
                {
                    interactCount = 0f;
                    interacting = false;
                    Debug.Log("Interact finished");
                }
            }
        }

        if (Input.GetButtonUp("Interact") && interacting == false)
        {
            interacting = true;
            Debug.Log("Can interact again");
        }
    }
}
