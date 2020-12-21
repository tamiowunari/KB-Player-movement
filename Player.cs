using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or [SerializeField] private...
    [SerializeField] private Transform groundCheckTransform;
    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private int superJump = 7;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame |Check for inputs here and apply forces/physics in the fixedUpdate method...
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space key was hit");
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //fixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput*2, rigidBodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        if (jumpKeyPressed == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * superJump, ForceMode.VelocityChange);
            jumpKeyPressed = false;
            superJump = 7;
        }
    }
