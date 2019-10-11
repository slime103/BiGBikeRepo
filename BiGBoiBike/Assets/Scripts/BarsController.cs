using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsController : MonoBehaviour
{
    public float maxRotation;
    public float minRoation;
    public float midPoint;

    public float rotateSpeed;
    public float currentRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,Mathf.Clamp(transform.localEulerAngles.y, minRoation, maxRotation),transform.localEulerAngles.z);

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {

            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentRotation +=  rotateSpeed * Time.deltaTime;
            transform.localEulerAngles =
                new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y+currentRotation, transform.localEulerAngles.z);

            
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentRotation -= rotateSpeed * Time.deltaTime;
            transform.localEulerAngles =
                new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + currentRotation, transform.localEulerAngles.z);

        }
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
        {
            currentRotation = 0;
        }
    }
}
