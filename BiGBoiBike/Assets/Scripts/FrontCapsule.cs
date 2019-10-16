using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCapsule : MonoBehaviour
{
    public Rigidbody rb;
    public float turnForce;
    public BarsController hbAxis;
    public BikeController bkController;
    public Rigidbody backWheel;

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
        if (Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) > bkController.turnThreshHold)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if ((hbAxis.currentAxisRoation - hbAxis.midPoint) > 0)
                {
                    rb.AddForce(transform.right * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * turnForce * backWheel.velocity.magnitude);
                }
                else
                {
                    rb.AddForce(transform.right * Mathf.Abs(hbAxis.currentAxisRoation - hbAxis.midPoint) * -turnForce * backWheel.velocity.magnitude);
                }
            }
        }
    }
}
