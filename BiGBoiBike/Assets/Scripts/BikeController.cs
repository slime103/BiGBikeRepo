using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public float forcePower;
    public float torquePower;
    public Rigidbody rb;
    public Rigidbody frontWheel;
    public float turnThreshHold;
    public BarsController hbAxis;
    public float turnSpeed;
    public float brakes;
    public float startDrag;
    public float counterSteer;
    float tempPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempPower = forcePower;
    }

    // Update is called once per frame
    void Update()
    {        

    }

    private void FixedUpdate()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forcePower, ForceMode.Acceleration); 
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.drag = brakes;
        }

        // real physics -- adds torque to bike
        /*
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0,-1,0)*torquePower); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(new Vector3(0,1,0)*torquePower); 
        }
        */
        else
        {
            rb.drag = startDrag;
        }

        if (Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) > turnThreshHold)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if ((hbAxis.currentAxisRoation - hbAxis.midPoint) > 0)
                {
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * torquePower * rb.velocity.magnitude);
                }
                else
                { 
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * -torquePower * rb.velocity.magnitude);
                }
            }
        }
        
        //Debug.Log(Mathf.Abs(hbAxis.midPoint - hbAxis.currentAxisRoation));
        //Debug.Log(rb.velocity.magnitude);
    }
}
