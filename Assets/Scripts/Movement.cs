using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float gravity;
    public float jump;

    public float y;
    public float x;
    public float z;

    public Vector3 right;
    public Vector3 forward;

    // Update is called once per frame
    void Update()
    {   
        if( controller.isGrounded && y < 0 )
        {
            y = -1f;
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        
            right = transform.right;
            forward = transform.forward;
        }

        Vector3 move = right * x + forward * z;

        move *= speed;

        move.y = y;

        if(Input.GetButtonDown("Jump") && controller.isGrounded )
        {
            move.y = Mathf.Sqrt( jump * -2f * gravity );
        }

        move.y += gravity * Time.deltaTime;

        y = move.y;

        controller.Move(move * Time.deltaTime);
    }
}
