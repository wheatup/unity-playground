using System.Collections.Generic;
using UnityEngine;

public static class Whevent {
	private static bool debug = true;
	private static Dictionary<string, List<System.Action<object[]>>> listeners = new Dictionary<string, List<System.Action<object[]>>>();

	public static void On(string eventName, System.Action<object[]> listener) {
		if (!listeners.ContainsKey(eventName)) {
			listeners[eventName] = new List<System.Action<object[]>>();
		}

		if(!listeners[eventName].Contains(listener)) {
			listeners[eventName].Add(listener);
		}
	}

	public static void Off(string eventName, System.Action<object[]> listener) {
		if (!listeners.ContainsKey(eventName)) {
			return;
		}

		if(!listeners[eventName].Contains(listener)) {
			return;
		}

		listeners[eventName].Remove(listener);
	}

	public static void Emit(string eventName, params object[] args) {
		if(debug) {
			Debug.Log("Emit: " + eventName);
		}

		if (!listeners.ContainsKey(eventName)) {
			return;
		}

		foreach (System.Action<object[]> listener in listeners[eventName]) {
			listener(args);
		}
	}
}