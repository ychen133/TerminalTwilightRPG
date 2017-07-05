using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject ListArea;

	private bool buttonSelected = false;


	void Update () {
		if (Input.GetAxisRaw ("Vertical") != 0 && !buttonSelected && ListArea.transform.childCount > 0) {
			eventSystem.SetSelectedGameObject (ListArea.transform.GetChild(0).gameObject);
			buttonSelected = true;
		}
	}

	private void OnDisable () {
		buttonSelected = false;
	}
}
