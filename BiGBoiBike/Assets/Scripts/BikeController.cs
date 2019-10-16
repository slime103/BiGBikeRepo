using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float forcePower;
    public float torquePower;
    public Rigidbody rb;
    public float turnThreshHold;
    public BarsController hbAxis;
    public float turnSpeed;
    public float brakes;
    public float startDrag;

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
            rb.AddForce(transform.forward * forcePower, ForceMode.Acceleration); 
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.drag = brakes;
        }
        else
        {
            rb.drag = startDrag;
        }
        /*
        if (Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) > turnThreshHold)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if ((hbAxis.currentAxisRoation - hbAxis.midPoint) > 0)
                {
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * torquePower * rb.velocity.magnitude * turnSpeed);
                }
                else
                {
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * torquePower * rb.velocity.magnitude * -turnSpeed);
                }
            }
        }
        */
        //Debug.Log(Mathf.Abs(hbAxis.midPoint - hbAxis.currentAxisRoation));
        //Debug.Log(rb.velocity.magnitude);
    }
}
