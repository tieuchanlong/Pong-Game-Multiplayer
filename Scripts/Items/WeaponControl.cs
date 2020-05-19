using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private bool attack = false;
    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
            Rotate();
    }

    void Rotate()
    {
        angle = angle + Time.deltaTime * 500;

        if (angle > 360f)
        {
            angle = 0f;
            attack = false;
            gameObject.SetActive(false);
        }

        transform.localEulerAngles = new Vector3(90f, angle, 0f);
    }

    public void SetAttack()
    {
        attack = true;
    }
}
