using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit: MonoBehaviour {
	private Color originalColor;

	void Awake() {
		originalColor = GetComponent<Renderer>().material.color;
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<MeshRenderer>().material.color = Color.red;
			tag = "Hit";
		}
	}

	private void OnCollisionExit(Collision other) {
		if (other.gameObject.tag == "Player") {
			GetComponent<MeshRenderer>().material.color = originalColor;
		}
	}
}
