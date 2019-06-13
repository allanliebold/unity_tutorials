using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  
  public float walkSpeed = 5;
  public float jumpSpeed = 5;
  Rigidbody rb;
  
  void Start () {
    rb = GetComponent<Rigidbody>();
  }
  
  void FixedUpdate () {
    WalkHandler(); 
  }
  
  void WalkHandler () {
    float hAxis = Input.GetAxis("Horizontal");
    float vAxis = Input.GetAxis("Vertical");
    
    Vector3 movement = new Vector3(hAxis * walkSpeed * Time.deltaTime, 0, vAxis * walkSpeed * Time.deltaTime);
  }
}

void JumpHandler() {
  float jAxis = Input.GetAxis("Jump"); 
  
  if(jAxis > 0) {
    Vector3 jumpVector = new Vector3();
  }
}
