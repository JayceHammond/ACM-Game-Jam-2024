using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour {

	public Quaternion rot;
	float rotSpeed = 40f;
	public Animator anim;
	public Camera playerCam;
    public float jumpForce;
    public bool isGrounded;

	// Use this for initialization
	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = new Quaternion(0, playerCam.transform.rotation.y, 0, transform.rotation.w);
		CheckKey();
        Debug.Log(isGrounded);

	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
            transform.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

        if(Input.GetKey(KeyCode.S)){
            transform.GetComponent<Rigidbody>().AddForce(-transform.forward, ForceMode.Impulse);
            anim.SetBool("Walk_Anim", true);
        }else if (Input.GetKeyUp(KeyCode.S)){
            anim.SetBool("Walk_Anim", false);
        }
/*
		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

/*
		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}
*/

		//Jump
		if(Input.GetKeyDown(KeyCode.Space)){
			if(isGrounded){
                Debug.Log("Grounded");
                transform.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
		}


		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}



    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }

}
