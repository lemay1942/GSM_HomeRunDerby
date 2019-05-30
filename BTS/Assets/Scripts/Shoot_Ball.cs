using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot_Ball : MonoBehaviour
{
    public GameObject BALL;
    public GameObject STRIKE_ZONE;

    public float ballSped;

    private GameObject createBall;
    private Vector3 addVect;
    private Rigidbody ballRB;

    private int startTime;
    private int nowTime;
    private int prevTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Convert.ToInt32(Time.time);
        prevTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = Convert.ToInt32(Time.time);
        if (Convert.ToInt32(nowTime - startTime) % 2 == 0)
        {
            if(nowTime != prevTime)
            {
                createBall = Instantiate(BALL, this.transform.position, Quaternion.identity);

                addVect = STRIKE_ZONE.transform.position - transform.position;
                addVect.Normalize();
                createBall.GetComponent<Rigidbody>().velocity = addVect * ballSped;

                prevTime = nowTime;
            }
        }

        if (createBall != null)
        {
            //addVect = STRIKE_ZONE.transform.position - this.transform.position;
            //addVect.Normalize();
            //createBall.transform.position += addVect;

            //createBall.transform.position += new Vector3(0, 0, Time.deltaTime * ballSped);
        }
    }
}
