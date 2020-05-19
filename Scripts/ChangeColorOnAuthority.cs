using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnAuthority : NetworkBehaviour
{
    /// <summary>
    /// Called when a client when they receive authority over an object, not called during server 
    /// </summary>
    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
