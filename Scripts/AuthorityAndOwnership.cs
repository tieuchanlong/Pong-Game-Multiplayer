using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AuthorityAndOwnership : NetworkBehaviour
{
    private GameObject _somePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool playerDead = false;

        // Check for authority before respawning
        if (playerDead && base.hasAuthority)
            CmdRequestRespawn();

        RequestOwnershipOnClick();
    }

    [Command]
    private void CmdRequestRespawn()
    {
        // Request Spawn using Network Identity, and Getcomponet... tells which client to give authority to
        NetworkServer.Spawn(_somePrefab, GetComponent<NetworkIdentity>().connectionToServer);
    }


    /// <summary>
    /// Traces for an object in the scene then tries to take ownership of it
    /// </summary>
    private void RequestOwnershipOnClick()
    {
        /*
         * This logic sends a command. Since commands cannot be sent without authority
         * there is no reason to continue if the client does not have authority
         */

        if (!base.hasAuthority)
            return;

        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            NetworkIdentity id = hit.collider.GetComponent<NetworkIdentity>();
            /*
             * If other object has a NetworkIdentity and client doesnt already own 
             * that object then request authority for it 
             */
            if (id != null && !id.hasAuthority)
            {
                Debug.Log("Sending request authority for " + hit.collider.gameObject.name);
                CmdRequestAuthority(id);
            }
        }
    }

    [Command]
    private void CmdRequestAuthority(NetworkIdentity otherId)
    {
        Debug.Log("Received request authority for " + otherId.gameObject.name);
        otherId.AssignClientAuthority(base.connectionToClient);
    }
}
