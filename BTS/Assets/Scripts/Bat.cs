using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;

public class Bat : MonoBehaviour
{
    public GameObject ball;

    public float ballSpeedY;
    public float ballSpeedZ;

    private InputDevice device;
    private HapticCapabilities capabilities;
    private Vector3 hitPosition;
    private Quaternion hitRotation;
    private Rigidbody rg;

    private void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT!");

        hitPosition = collision.transform.position;
        hitRotation = collision.transform.rotation;

        Debug.Log(hitPosition);
        Debug.Log(hitRotation);

        Destroy(collision.gameObject);
        GameObject createBall = Instantiate(ball, hitPosition, hitRotation);

        rg = createBall.GetComponent<Rigidbody>();
        rg.AddForce(new Vector3(0, ballSpeedY * Time.deltaTime * 10000, ballSpeedZ * Time.deltaTime * 10000));

        StartCoroutine(hapticCoroutine());
    }

    IEnumerator hapticCoroutine()
    {
        haptic(0.7f);
        Debug.Log("haptic ON");
        yield return new WaitForSeconds(1);
        haptic(0);
        Debug.Log("haptic OFF");
    }

    private void haptic(float amplitude)
    {
        if (device.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                uint channel = 0;
                device.SendHapticImpulse(channel, amplitude);
            }
        }
    }
}
