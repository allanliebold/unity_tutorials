using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {
	
	public float scaleFactor = 1.2f;
	public float maxScale = 3f;
	public float maxY = 10f;
	public float minY = -10f;
	public float speed = 0.1f;
	Vector3 vector;
	
	void Start() {
		if(scaleFactor <= 1) {
			print("scaleFactor too low.");	
		}
		
		vector = new Vector3(1, 1, 1);
	}
	
	void OnMouseDown() {
		
	}

	void Update() {
		transform.position += speed * vector;
		if (transform.position.y >= maxY && speed > 0) {
			speed *= -1;
		} else if (transform.position.y <= minY && speed < 0) {
			speed *= -1;
		}
	}
}
