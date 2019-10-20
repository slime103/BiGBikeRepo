using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    public LayerMask ground;
    public float rayDist;
    public Rigidbody bikeRb;
    float tempTorquePower;
    public BikeController BkController;
    public FrontCapsule fCapsule;
    float tempTforce;

    // Start is called before the first frame update
    void Start()
    {
        tempTorquePower = BkController.torquePower;
        tempTforce = fCapsule.turnForce;
    }

    // Update is called once per frame
    void Update()
    {
        Ray tiltRay = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(this.transform.position, Vector3.down, Color.red, rayDist);
        RaycastHit hit;
        if (Physics.Raycast(tiltRay, out hit, rayDist, ground))
        {
            BkController.torquePower = tempTorquePower;
            fCapsule.turnForce = tempTforce;
        }
        else
        {
            Debug.Log("Flying!");
            tempTorquePower = BkController.torquePower;
            tempTforce = fCapsule.turnForce;
            BkController.torquePower = 0;
            fCapsule.turnForce = 0;
        }
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(-bikeRb.velocity.magnitude, 0, 0);
    }
}
