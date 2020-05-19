using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class Movement : NetworkBehaviour
{
    public float speed = 10f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public Vector3 force;
    private bool isJumping = false;

    public Transform cam;

    public GameObject cube;

    [SyncVar] public bool Spawned;
    [SyncVar] private float delayCount = 0f;
    [SyncVar] [SerializeField] private float delayMax = 1f;

    private void Awake()
    {
        //CmdAssignNetworkAuthority(GetComponent<NetworkIdentity>(), GetComponent<NetworkIdentity>());

        
    }

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (base.hasAuthority)
        {
            MovePlayer();
            //RotateCamera();
            //Jump();
            //SlowTime();
            if (Input.GetKey(KeyCode.Space))
            {
                if (delayCount <= 0)
                {
                    if (isServer)
                        RpcSpawn();
                    else if (isClient)
                        CmdSpawn(true);
                }

                if (isServer)
                {
                    delayCount += Time.deltaTime;
                    if (delayCount >= delayMax)
                        delayCount = 0;
                }
            }
            else
            {
                delayCount = 0;
                CmdSpawn(false);
            }
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            if (isClient)
            {
                if (Spawned)  // click space on client
                {
                    if (delayCount <= 0)
                    {
                        RpcSpawn();
                        //Debug.Log("Hey");
                    }
                        

                    delayCount += Time.deltaTime;
                    CmdUpdateCount(delayCount);
                    if (delayCount >= delayMax)
                    {
                        delayCount = 0;
                        CmdUpdateCount(delayCount);
                    }
                    //Spawned = false;
                }
                else
                {
                    Spawned = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        Jump();
    }

    void RotateCamera()
    {
        yaw += Input.GetAxis("Mouse X") * speed;
        //pitch -= Input.GetAxis("Mouse Y") * speed;

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

    }

    void MovePlayer()
    {
        if (!base.hasAuthority) return;
        //CmdUpdatePosition();

        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += camF * z * Time.deltaTime + camR * x * Time.deltaTime;

        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }*/
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            isJumping = true;
        }
    }

    void SlowTime()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = 0.5f;
        }
        else Time.timeScale = 1f;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isJumping == true)
        {
            isJumping = false;
        }
    }

    [Command]
    public void CmdAssignNetworkAuthority(NetworkIdentity cubeId, NetworkIdentity clientId)
    {
        //If -> cube has a owner && owner isn't the actual owner
        if (cubeId.clientAuthorityOwner != null && cubeId.clientAuthorityOwner != clientId.connectionToClient)
        {
            // Remove authority
            cubeId.RemoveClientAuthority(cubeId.clientAuthorityOwner);
        }

        //If -> cube has no owner
        if (cubeId.clientAuthorityOwner == null)
        {
            // Add client as owner
            cubeId.AssignClientAuthority(clientId.connectionToClient);
        }
    }

    [Command]
    private void CmdUpdateCount(float x)
    {
        delayCount = x;
        Debug.Log(delayCount);
    }

    [Command]
    private void CmdUpdatePosition()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += camF * z * Time.deltaTime + camR * x * Time.deltaTime;
    }

    [ClientRpc]
    void RpcSpawn()
    {
        GameObject cube1 = Instantiate(cube) as GameObject;
        cube1.transform.forward = transform.forward;
        cube1.transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1);
        NetworkServer.Spawn(cube1);
    }

    [Command]
    void CmdSpawn(bool check)
    {
        Spawned = check;
    }
}
