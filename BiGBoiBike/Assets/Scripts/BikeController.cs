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

            if (Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) > turnThreshHold)
            {
                if ((hbAxis.currentAxisRoation - hbAxis.midPoint) > 0)
                {
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * torquePower * turnSpeed);
                }
                else
                {
                    rb.AddTorque(transform.up * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * torquePower * -turnSpeed);
                }
            }

            Debug.Log(Mathf.Abs(hbAxis.midPoint - hbAxis.currentAxisRoation));
        }
    }
}
