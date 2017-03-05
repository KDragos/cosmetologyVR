using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigation : MonoBehaviour {
	public Material materialNormal;
	public Material materialHover;
	public GameObject player;
	public GameObject researchEngine;
	public Canvas canvas;

	private ResearchEngine engine;

	private Renderer renderer;
	public float speed;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<Renderer> ();
		engine = researchEngine.GetComponent<ResearchEngine> ();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Check to render the point.
	}

	public void onStartHover() {
		// On hover, change material to the darker less translucent material. 
		renderer.material = materialHover;

	}

	public void onEndHover() {
		// on hover exit, change material to lighter material.
		renderer.material = materialNormal;
	}

	public void onClick() {
		// On click, move player to the targetted waypoint using iTween.
		iTween.MoveTo(player, iTween.Hash(
			"x", gameObject.transform.position.x,
			"z", gameObject.transform.position.z,
			"time", speed
		));
			
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag.Equals("Player")) {
			renderer.enabled = false;
			engine.Play (gameObject.name);
			// Activate the waypoint's canvas if it has one. 
			Debug.Log("Starting canvas status: " + canvas.enabled.ToString());
			if (canvas != null) {
				canvas.enabled = true;
			}
			Debug.Log("Ending canvas status: " + canvas.enabled.ToString());

		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag.Equals("Player")) {
			renderer.enabled = true;	
			engine.Stop ();
			// Deactivate canvas if it has one.
			if (canvas != null) {
				canvas.enabled = false;
			}

		}
	}
}
