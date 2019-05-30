using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    public bool spinTF;

    private float rotX = -10f;
    private float rotZ = 5f;

    void Update()
    {
        if(spinTF) transform.Rotate(new Vector3(rotX, 0, rotZ), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotX = 0;
        rotZ = 0;
    }
}
