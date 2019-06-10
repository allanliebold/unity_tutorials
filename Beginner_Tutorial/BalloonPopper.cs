using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {
	
	public float scaleFactor = 1.2f;
	public float maxScale = 3f;
	public float speed = 0.1f;
	Vector3 vector;
	
	void Start() {
		if(scaleFactor <= 1) {
			print("scaleFactor too low.");	
		}
		
		vector = new Vector3(1, 1, 1);
	}

	void Update() {

	}
}
