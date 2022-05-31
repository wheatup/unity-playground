using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover: MonoBehaviour {
	[SerializeField] float moveSpeed = 5f;

	void LateUpdate() {
		HandleMovement();
	}

	private void HandleMovement() {
		Vector2 inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (inputAxis.magnitude > 1f) inputAxis.Normalize();

		Vector3 force = new Vector3(inputAxis.x * Time.deltaTime * moveSpeed, 0, inputAxis.y * Time.deltaTime * moveSpeed);
		transform.Translate(force);
	}
}
