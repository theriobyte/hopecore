using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    public float speed = 9.5f;
    public float rotationSpeed = 2.0f;
    
    public float horizontalInput;
    public float verticalInput;
    public float mouseXInput;
    //public float mouseYInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, -mouseXInput * rotationSpeed, 0));
        

    }
}