using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingCharacter : Character
{
    private bool isJumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
    }

    public override void MoveToPoint()
    {
        base.MoveToPoint();
        Hopping();
    }

    private void Hopping()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (isJumping == false)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, 20f, 0f), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJumping == true)
        {
            isJumping = false;
            Debug.Log("OnGround");
        }
    }
}
