using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;

    public Transform affectPos;
    public LayerMask whatIsAffecting;
    public float affectRange;

    private float run_scale = 1.5f;

    public GameObject MainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetButton("Run"))
        {
            horizontal *= run_scale;
            vertical *= run_scale;
        }

        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y, transform.position.z + vertical);
        ChangeCameraView();
    }

    void ChangeCameraView()
    {
        Collider[] affectingObj = Physics.OverlapSphere(affectPos.position, affectRange, whatIsAffecting);

        if (affectingObj.Length > 0)
        {
            MainCam.GetComponent<Camera>().orthographicSize -= 0.05f;
            MainCam.GetComponent<Camera>().orthographicSize = Mathf.Max(MainCam.GetComponent<Camera>().orthographicSize, 5.0f);
        }
        else
        {
            MainCam.GetComponent<Camera>().orthographicSize += 0.05f;
            MainCam.GetComponent<Camera>().orthographicSize = Mathf.Min(MainCam.GetComponent<Camera>().orthographicSize, 7.0f);
        }

        // In case of wall detection, move camera closer as well
        var ray = Camera.main.ScreenPointToRay(MainCam.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(affectPos.position, affectRange);
    }
}
