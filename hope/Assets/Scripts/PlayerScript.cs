using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Transform cam;

    public int healthP = 5; // ?? add health
    public float speed = 9.5f;
    public float rotationSpeed = 2.0f;
    public bool canJump = false;

    private float horizontalInput;
    private float verticalInput;
    private float mouseXInput;
    private float mouseYInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseXInput * rotationSpeed, 0));

        mouseYInput = Input.GetAxis("Mouse Y");
        cam.transform.Rotate(new Vector3(-mouseYInput * rotationSpeed, 0, 0));

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector3(0, 5, 0);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
        {
            //Debug.Log("canjump");
            canJump = true;
        }
    }
}