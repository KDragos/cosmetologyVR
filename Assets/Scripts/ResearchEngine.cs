using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchEngine : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip[] audioClips;
	public Canvas exitCanvasFront;
	public Canvas exitCanvasBack;
	private Dictionary<string, AudioClip> research;

	void Start () {
		SetCanvasesEnabled (false);
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
		SetCanvasesEnabled (true);
		Play ("Goodbye");
	}

	public void DoorCancel() {
		SetCanvasesEnabled (false);

	}

	public void DoorQuit() {
		Debug.Log ("Quitting game.");
		Application.Quit ();
	}

	private void SetCanvasesEnabled(bool status) {
		exitCanvasFront.enabled = status;
		exitCanvasBack.enabled = status;
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
