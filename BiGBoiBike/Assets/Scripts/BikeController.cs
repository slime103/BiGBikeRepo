using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float turnSpeed = 1;
    public float lerpSpeed = 0.7f;
    public float angleLimit = 30;

    public Rigidbody rb;

    public float angleTraveled;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            angleTraveled += turnSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, angleTraveled, 0);
            if (transform.eulerAngles.y > angleLimit)
            {
                transform.eulerAngles = new Vector3(0, angleLimit, 0);
            }
        }
    }
}
