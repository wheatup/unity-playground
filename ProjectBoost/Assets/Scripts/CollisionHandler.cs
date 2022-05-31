using UnityEngine;

public class CollisionHandler: MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		switch (other.gameObject.tag) {
			case "Obstacle":
			case "Ground":
				Whevent.Emit("PLAYER_DIED");
				break;

			case "Finish":
				Whevent.Emit("WIN");
				break;
		}
	}
}
