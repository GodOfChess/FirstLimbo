using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float waterSpeed = 1f;
    public float gravity = 20F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Water")
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            moveDirection.y = -waterSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y += 3*waterSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                moveDirection.y -= 3 * waterSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Water")
        {
            gravity = 0;
        }
        else
        {
            gravity = 20;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Water")
        {
            gravity = 20;
        }
    }
}
