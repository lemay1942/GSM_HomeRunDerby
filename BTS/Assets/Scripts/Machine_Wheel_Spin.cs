using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Wheel_Spin : MonoBehaviour
{
    public int LR_Spin;         // -1 : Right Spin, 1 : Left Spin, 0 : Stop

    private float spin_Speed = 0f;

    const float MAX_SPEED = 1000f;
    
    void Update()
    {
        if(LR_Spin != 0)
        {
            this.transform.Rotate(LR_Spin * spin_Speed * Time.deltaTime, 0, 0, Space.World);     // Wheels rotation

            if(spin_Speed != MAX_SPEED) spin_Speed += 10f;                     // max speed
        }
    }
}
