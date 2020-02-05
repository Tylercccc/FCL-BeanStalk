using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{

    // Use this for initialization
    public float speed = 1;
    public float RotAngleY = 45;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rY = Mathf.SmoothStep(-25, RotAngleY, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(0, 0, rY);
    }
}
