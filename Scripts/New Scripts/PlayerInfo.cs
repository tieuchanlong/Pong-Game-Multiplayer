using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private float health = 100f;
    private float strength = 100f;
    private float mentality = 100f;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public float Mentality
    {
        get { return mentality; }
        set { mentality = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
