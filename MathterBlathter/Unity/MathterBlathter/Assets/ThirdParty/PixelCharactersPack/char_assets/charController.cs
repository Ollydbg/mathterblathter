using UnityEngine;
using System.Collections;
using System;

public class charController : MonoBehaviour 
{
	public float moveSpeed = 3.0f;
	public float jumpForce = 300.0f;
	private Vector2 moveDir;
	private Animator anim;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		moveDir = Vector2.zero;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		float moveX = Input.GetAxis ("Horizontal");
		moveDir = new Vector2 (moveX, 0);
		moveDir.Normalize ();
		anim.SetFloat ("Speed", Math.Abs(moveX));
		
		//horizontal move control
		transform.position += new Vector3 (moveDir.x, moveDir.y, 0.0f)*moveSpeed*Time.deltaTime;
		if (moveX > 0) 
		{
			transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		else if (moveX < 0) 
		{
			transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		
		//jump control
		if (rb.velocity.y >= -0.01f && rb.velocity.y <= 0.01f && Input.GetKeyDown (KeyCode.Space)) 
		{
			rb.AddForce(new Vector2(0, jumpForce));
		}
		anim.SetFloat ("vSpeed", rb.velocity.y);
	}
}
