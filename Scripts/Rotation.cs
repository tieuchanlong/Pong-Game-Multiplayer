using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private GameObject player;
    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(30, 90, 100);
        player.transform.localRotation = rotation;
    }
}
