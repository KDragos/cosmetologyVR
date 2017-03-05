using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchEngine : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip[] audioClips;
	public Canvas exitCanvas;
	private Dictionary<string, AudioClip> research;

	void Start () {
		exitCanvas.enabled = false;
		SetupDictionary ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void Play(string name) {
		if (research.ContainsKey (name)) {
			audioSource.clip = research [name];
			audioSource.Play();
		}
	}

	public void Stop () {
		audioSource.Stop();
	}

	public void Door() {
		if (exitCanvas == null) {
			Debug.Log ("canvas is null");
		}
		if (exitCanvas.enabled) {
			Debug.Log ("Canvas is enabled");
		}
		if (!exitCanvas.enabled) {
			Debug.Log ("canvas isn't enabled.");
		}
		exitCanvas.enabled = true;
		if (exitCanvas.enabled) {
			Debug.Log ("Canvas is enabled");
		}
		if (!exitCanvas.enabled) {
			Debug.Log ("canvas isn't enabled.");
		}
		Play ("Goodbye");
	}

	public void DoorCancel() {
		exitCanvas.enabled = false;
	}

	public void DoorQuit() {
		Debug.Log ("Quitting game.");
		Application.Quit ();
	}

	private void SetupDictionary() {
		research = new Dictionary<string, AudioClip> ();
		research.Add ("Welcome", audioClips [6]);
		research.Add ("Reception", audioClips [3]);
		research.Add ("Styling1", audioClips [4]);
		research.Add ("Shampoo", audioClips [5]);
		research.Add ("Dispensary", audioClips [0]);
		research.Add ("BreakRoom", audioClips [1]);
		research.Add ("Nails", audioClips [2]);
		research.Add ("Goodbye", audioClips [7]);

	}
}
