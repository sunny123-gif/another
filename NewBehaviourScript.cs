using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public float speed = 0;
	public float movementspeed =0;
	public float run = 0;

	private Vector3 movedirection;
	private Vector3 velocity;

	[SerializeField] private bool isgrounded;
	[SerializeField] private float groundcheck;
	[SerializeField] private LayerMask ground;

	public CharacterController controller;


	// Use this for initialization
	private void Start () {
		controller = controller.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	private void Update () {
		Move ();
	}
	private void Move(){
		isgrounded = Physics.CheckSphere (transform.position, groundcheck, ground);
		if (isgrounded && velocity.y < 0) {
			velocity.y = -2f;
		}

		float movez = Input.GetAxis ("Vertical");
		float movey = Input.GetAxis ("Horizontal");

		movedirection = new Vector3 (movey, 0, movez);


		if(movedirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
			run1 ();

		}
		else if(movedirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){

			walk ();
		}
		else if(movedirection == Vector3.zero ){
			idle ();

		}
		movedirection *= movementspeed;
 		controller.Move (movedirection * Time.deltaTime);


	}
	private void run1(){
		movementspeed = speed;
	}
	private void walk(){
		movementspeed = run;
	}
	private void idle(){

	}
}
