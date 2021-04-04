using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    public GameObject bl,bubble , Etext, rychagTrue, rychagFalse;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float waterSpeed = 1f;
    public float gravity = 20F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Animator anim;
	public GameObject door;
	private bool isOpen = false, isPlane1 =false, isPlane2 =false;
	public AudioSource audio1, audio2;

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
		if (col.tag == "Rychag")
		{
			if (Input.GetKey(KeyCode.E))
			{
				rychagTrue.SetActive(true);
				rychagFalse.SetActive(false);
				door.SetActive(false);
				Etext.SetActive(false);
				isOpen = true;
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
        if (col.tag == "Blur")
        {
            bl.SetActive(false);
            bubble.SetActive(false);
        }
		if (col.tag == "triggerlvl2")
		{
			SceneManager.LoadScene(4);
		}
		if (col.tag == "Rychag" && !isOpen)
		{
			Etext.SetActive(true);
		}
		else
		{
			Etext.SetActive(false);
		}
		if (col.tag == "plane1" && !isPlane1)
		{
			audio1.Play();
			isPlane1 = true;
		}
		if (col.tag == "plane2" && !isPlane2)
		{
			audio2.Play();
			isPlane2 = true;
		}
		if (col.tag == "End")
		{

		}
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Water")
        {
            gravity = 20;
        }
        if (col.tag == "Blur")
        {
            bl.SetActive(true);
            bubble.SetActive(true);
        }
		if (col.tag == "Rychag")
		{
			Etext.SetActive(false);
		}
    }
}
