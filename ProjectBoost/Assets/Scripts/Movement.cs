using UnityEngine;

public class Movement: MonoBehaviour {
	[SerializeField] float thrustPower = 1000f;
	[SerializeField] float tiltPower = 200f;

	private Rigidbody rb;
	private AudioSource thrustSound;
	private bool controllable = true;

	void Awake() {
		this.controllable = true;
		this.rb = GetComponent<Rigidbody>();
		this.thrustSound = GetComponent<AudioSource>();

		Whevent.On("PLAYER_DIED", this.onFinish);
		Whevent.On("WIN", this.onFinish);
	}

	void LateUpdate() {
		if (this.controllable) {
			this.HandleInput();
		}
	}

	void OnDestroy() {
		Whevent.Off("PLAYER_DIED", this.onFinish);
		Whevent.Off("WIN", this.onFinish);
	}

	void onFinish(params object[] args) {
		if (this.controllable) {
			this.controllable = false;
			if (this.thrustSound.isPlaying) {
				this.thrustSound.Stop();
			}
			this.rb.constraints = RigidbodyConstraints.None;
		}
	}

	private void HandleInput() {
		float tilt = Input.GetAxis("Horizontal");
		bool thrusting = Input.GetButton("Jump");

		if (thrusting) {
			this.rb.AddRelativeForce(Vector3.up * this.thrustPower * Time.deltaTime);
			if (!this.thrustSound.isPlaying) {
				this.thrustSound.Play();
			}
		} else {
			if (this.thrustSound.isPlaying) {
				this.thrustSound.Stop();
			}
		}

		if (tilt != 0f) {
			this.rb.AddRelativeTorque(Vector3.back * this.tiltPower * tilt * Time.deltaTime);
		}
	}
}
