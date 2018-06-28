using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	[Tooltip("Time delay (in seconds) before self-destructing")]
	public float delay;

	void Start () {
		Destroy(this.gameObject, delay);
	}
}
