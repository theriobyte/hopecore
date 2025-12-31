using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public WeaponScript weaponScript;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Transform cam;

    public int healthP = 5; // ?? add health
    public float speed = 9.5f;
    public float rotationSpeed = 2.0f;
    public bool canJump = false;
    public bool canMove = true;
    public bool canLook = true;
    public bool canUseWeapon = false;


    private float fire1Input;
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
        if (canMove)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        }
        if (canLook)
        {
            mouseXInput = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, mouseXInput * rotationSpeed, 0));

            mouseYInput = Input.GetAxis("Mouse Y");
            cam.transform.Rotate(new Vector3(-mouseYInput * rotationSpeed, 0, 0));

            
        }
        
        //Debug.Log(cam.transform.rotation);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector3(0, 5, 0);
            canJump = false;
        }

        fire1Input = Input.GetAxis("Fire1");

        if (canUseWeapon)
        {
            if (fire1Input == 1)
            {
                weaponScript.weaponFire();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jumpable"))
        {
            //Debug.Log("canjump");
            canJump = true;
        }
        if (other.gameObject.CompareTag("CantMove"))
        {
            Debug.Log("shouldnt be able to move");
            canMove = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("CantMove"))
        {
            Debug.Log("should be able to move");
            canMove = true;
        }
    }
}