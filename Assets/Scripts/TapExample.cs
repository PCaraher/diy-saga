using UnityEngine;
using System.Collections;
using TMPro;

public class TapExample : MonoBehaviour {



	void Awake(){

	}
	void Start(){

	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)){
				if (hit.transform == transform) {
					Debug.Log("tapped object " + transform.name.ToString());
				}
			}
		}
	}
}
