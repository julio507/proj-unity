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

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

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
