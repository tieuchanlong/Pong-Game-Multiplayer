using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    private float angle = 0;
    [SerializeField] private Coin coinScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        angle = angle + Time.deltaTime * 50;

        if (angle > 360f)
            angle = 0f;

        transform.localEulerAngles = new Vector3(90f, angle, 0f);
    }
}
