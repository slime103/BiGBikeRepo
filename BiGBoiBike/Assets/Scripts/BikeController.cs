using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float forcePower;
    public float torquePower;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forcePower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * torquePower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.up * -torquePower);
        }
    }
}
