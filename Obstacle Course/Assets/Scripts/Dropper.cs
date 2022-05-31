using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper: MonoBehaviour {
	[SerializeField] float timer = 3f;

	private MeshRenderer meshRenderer;
	private Rigidbody body;

	void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
		body = GetComponent<Rigidbody>();
		meshRenderer.enabled = false;
		body.useGravity = false;
	}

	void Update() {
		if (Time.time >= timer) {
			Drop();
		}
	}

	void Drop() {
		meshRenderer.enabled = true;
		body.useGravity = true;
	}
}
