using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {
     public string myGameIdea;
	
	void Start () {
	PrintGame();
	}
	
	void PrintGame () {
		print(myGameIdea);
	}
}

