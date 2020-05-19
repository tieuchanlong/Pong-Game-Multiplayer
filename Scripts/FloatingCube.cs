using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCube : MonoBehaviour
{
    private float maxHeight = 20f;
    private float minHeight = 10f;
    private int direction = 0;
    private float FloatSpeed = 2f;

    public float GetMaxHeight()
    {
        return maxHeight;
    }

    public float GetminHeight()
    {
        return minHeight;
    }

    public void Float()
    {
        if (direction == 0)
        {
            if (transform.position.y <= maxHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + FloatSpeed * Time.deltaTime, transform.position.z);
            }
            else direction = 1;
        }
        else
        {
            if (transform.position.y >= minHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - FloatSpeed * Time.deltaTime, transform.position.z);
            }
            else direction = 0;

        }
    }

    private void Update()
    {
        Float();
    }
}
