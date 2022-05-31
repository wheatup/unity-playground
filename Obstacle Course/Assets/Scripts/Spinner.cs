using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner: MonoBehaviour {
	[SerializeField] float speed = 20f;

	void Update() {
		transform.Rotate(Vector3.up, Time.deltaTime * speed);
	}
}
