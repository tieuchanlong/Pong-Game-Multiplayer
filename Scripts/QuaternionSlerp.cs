using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionSlerp : MonoBehaviour
{
    private Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPkayer();
    }

    public void LookAtPkayer()
    {
        Quaternion lookPlayer = Quaternion.LookRotation(Player.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookPlayer, Time.deltaTime); // if you dont use Quaternion.slerp the rotation will be sudden => Slerp will help rotate from quaterion a to quaternion b with speed as desired
    }
}
