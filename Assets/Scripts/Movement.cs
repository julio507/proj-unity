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

    public Vector3[] raycast =
    {
        Vector3.forward,
        Vector3.left,
        Vector3.left + Vector3.forward,
        Vector3.left + Vector3.back,
        Vector3.right,
        Vector3.right + Vector3.forward,
        Vector3.right + Vector3.back,
        Vector3.back
    };

    bool raycastWall()
    {
        RaycastHit[] hits = new RaycastHit[raycast.Length];

        bool result = false;

        for (int i = 0; i < raycast.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (Physics.Raycast(transform.position, transform.TransformDirection(raycast[i]), out hit, 1))
            {
                result = true;
            }
        }

        return result;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && y < 0)
        {
            y = -1f;

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            right = transform.right;
            forward = transform.forward;
        }

        bool isWallruning = raycastWall() && !controller.isGrounded;

        Vector3 move = right * x + forward * z;

        move.y = y;

        if (Input.GetButtonDown("Jump") && (controller.isGrounded || isWallruning))
        {
            move.y = Mathf.Sqrt(jump * -2f * gravity);

            if (isWallruning)
            {
                right = transform.right;
                forward = transform.forward;

                move.x = right.x * x + forward.x * z;
                move.z = right.z * x + forward.z * z;
            }
        }

        if (isWallruning)
        {
            move.y += gravity / 2 * Time.deltaTime;

            Debug.Log("Wallrunnig");
        }

        else
        {
            move.y += gravity * Time.deltaTime;
        }

        y = move.y;

        if (speed > 10 && !isWallruning)
        {
            speed -= 1 * Time.deltaTime;
        }

        else if (speed < 15)
        {
            speed += 20 * Time.deltaTime;
        }

        move.x *= speed;
        move.z *= speed;

        controller.Move(move * Time.deltaTime);
    }
}
