using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RobotFreeAnim : MonoBehaviour {

	public Quaternion rot;
	float rotSpeed = 40f;
	public Animator anim;
	public Camera playerCmm;

	// Use this for initialization
	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Camera.main.transform.rotation;
		CheckKey();
	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
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

}
