using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsController : MonoBehaviour
{
    public float maxRotation;
    public float minRoation;
    public float midPoint;
    public float turnAngle;

    public float rotateSpeed;
    public float currentRotation = 0;
    public float currentAxisRoation;


    // Start is called before the first frame update
    void Start()
    {
        maxRotation = midPoint + turnAngle;
        minRoation = midPoint - turnAngle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,Mathf.Clamp(transform.localEulerAngles.y, minRoation, maxRotation),transform.localEulerAngles.z);
        currentAxisRoation = transform.localEulerAngles.y;

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {

            return;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentRotation +=  rotateSpeed * Time.deltaTime;
            transform.localEulerAngles =
                new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y + currentRotation, minRoation, maxRotation), transform.localEulerAngles.z);

            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotation -= rotateSpeed * Time.deltaTime;
            transform.localEulerAngles =
                new Vector3(transform.localEulerAngles.x, Mathf.Clamp(transform.localEulerAngles.y + currentRotation, minRoation, maxRotation), transform.localEulerAngles.z);

        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentRotation = 0;
        }
        Debug.Log(Mathf.Abs(currentAxisRoation - midPoint));
    }
}
