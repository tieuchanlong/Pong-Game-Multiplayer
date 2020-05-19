using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float Minx;
    [SerializeField] private float Maxx;
    [SerializeField] private float Minz;
    [SerializeField] private float Maxz;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BasicMovement();
    }

    void BasicMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float new_x = transform.position.x + horizontal * speed * Time.deltaTime;
        float new_z = transform.position.z + vertical * speed * Time.deltaTime;

        new_x = Mathf.Max(new_x, Minx);
        new_x = Mathf.Min(new_x, Maxx);
        new_z = Mathf.Max(new_z, Minz);
        new_z = Mathf.Min(new_z, Maxz);

        transform.position = new Vector3(transform.position.x + horizontal * speed * Time.deltaTime, transform.position.y, transform.position.z + vertical * speed * Time.deltaTime);
    }
}
