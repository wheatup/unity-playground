using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {
	private bool isAlive = true;

	void Awake() {
		Whevent.On("PLAYER_DIED", this.onPlayerDied);
		Whevent.On("WIN", this.onWin);
	}

	private void OnDestroy() {
		Whevent.Off("PLAYER_DIED", this.onPlayerDied);
		Whevent.Off("WIN", this.onWin);
	}

	private void onPlayerDied(params object[] args) {
		if (this.isAlive) {
			Invoke("ReloadLevel", 2f);
		}
		this.isAlive = false;
	}

	private void onWin(params object[] args) {
		if (!this.isAlive) return;
		Invoke("LoadNextLevel", 2f);
	}

	private void LoadNextLevel() {
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (SceneManager.sceneCountInBuildSettings - 1 == sceneIndex) {
			sceneIndex = 0;
		} else {
			sceneIndex++;
		}
		SceneManager.LoadScene(sceneIndex);
	}

	private void ReloadLevel() {
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneIndex);
	}
}
