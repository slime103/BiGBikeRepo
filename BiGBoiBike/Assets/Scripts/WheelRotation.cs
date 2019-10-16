using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{

    public LayerMask ground;
    public Rigidbody BikeRb;
    public float rayDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray tiltRay = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(this.transform.position, Vector3.down, Color.red, rayDist);
        RaycastHit hit;
        if (Physics.Raycast(tiltRay, out hit, rayDist, ground))
        {

        }
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(-BikeRb.velocity.magnitude, 0, 0);
    }
}
