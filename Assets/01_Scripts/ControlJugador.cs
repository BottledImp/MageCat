using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour {

	public float moveForce= 20f, jumpForce = 400f, maxVelocity = 4f;
	private bool grounded;
	private Rigidbody2D myBody;
	private Animator anim;


	void Awake (){
		InitializeVariables();

		}


	void FixedUpdate () {
		PlayerWalk ();
	}

	void InitializeVariables(){

		myBody = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
	}

	void PlayerWalk(){

		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (myBody.velocity.x);
		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {

			if (vel < maxVelocity) {
				if (grounded) {
					forceX = moveForce;
				} else {
					forceX = moveForce * 1.5f;
				}
			}
            //This is to flip the animations
			Vector3 scale = transform.localScale;
			scale.x=-1;
			transform.localScale = scale;
            anim.SetBool("RunL" = true);

			anim.SetBool ("Walk", true);

		} else if (h<0){

			if (vel < maxVelocity) {
				if (grounded) {
					forceX = -moveForce;
				} else {
					forceX = -moveForce * 1.5f;
				}
			}
			Vector3 scale = transform.localScale;
			scale.x=1;
			transform.localScale = scale;

			anim.SetBool ("RunR",true);

		} else if (h==0){
			anim.SetBool ("RunR",false);
            anim.SetBool("RunR", false);
        }
		if (Input.GetKey (KeyCode.Space)) {
			if (grounded) {
				grounded = false;
				forceY = jumpForce;
			}
		}
	myBody.AddForce (new Vector2 (forceX, forceY));
}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Ground") {
			grounded = true;
		}
	}
}

