using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    
    public Rigidbody rig;

    private bool isColliding;

    public float speed = 10.0f;
    public float jumpForce;

    public bool isUsingGravity;
    
    private Vector3 Jump;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rig = gameObject.GetComponent<Rigidbody>();
        Jump = new Vector3(0, jumpForce, 0);
        isUsingGravity = true;

    }

    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    void Update()
    {


        
        if (isUsingGravity== true)
        {
            float translate = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translate *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translate);

            //Used to coming down from a jump less floaty
            float yVel = rig.velocity.y;
            Vector3 newVel = transform.forward * translate + transform.right * straffe;
            newVel = newVel.normalized * speed;
            newVel.y = yVel;
            rig.velocity = newVel;

            if (Input.GetKeyDown("space") && rig.velocity.y == 0.0f)
            {
                rig.AddForce(Jump, ForceMode.Impulse);
            }
        }

      
        /// leaping from objects in space///
        
        if(isUsingGravity == false && isColliding == true)
        {
            
            if (Input.GetKeyDown("space"))
            {
                GameObject forwardTraj = GameObject.Find("bulletSpawn");
                rig.AddForce(forwardTraj.transform.forward * 40, ForceMode.Impulse);
            }
        }

        /// giving slight boost in space ///
        
        if (isUsingGravity == false && isColliding == false)
        {

            if (Input.GetKey("space"))
            {
                GameObject forwardTraj = GameObject.Find("bulletSpawn");
                rig.AddForce(forwardTraj.transform.forward * 1.5f, ForceMode.Acceleration);
            }
        }


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
       
    }
}
