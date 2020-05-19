using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatandRotateCube : FloatingCube
{
    private float RotationSpeed = 20;
    Vector3 currentAngle;
    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FloatRotate();
    }

    public void FloatRotate()
    {
        Float();

        currentAngle += new Vector3(1, 0, 0) * Time.deltaTime * RotationSpeed;
        currentRotation.eulerAngles = currentAngle;

        transform.rotation = currentRotation;
    }
}
