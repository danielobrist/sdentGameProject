using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private CharacterController controller;
	private Rigidbody rbody;
	private Animation anim;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20f;

		void Start () {
			controller = GetComponent <CharacterController>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				
			}  else {
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
}
