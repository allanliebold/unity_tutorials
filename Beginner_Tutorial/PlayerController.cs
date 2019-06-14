using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  
  public float walkSpeed = 5;
  public float jumpForce = 5;
  Rigidbody rb;
  bool pressedJump = false;
  
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
    bool isGrounded = CheckGrounded();
    if(!pressedJump) {
      Vector3 jumpVector = new Vector3(0, jAxis * jumpForce, 0);
      rb.AddForce(jumpVector, ForceMode.VelocityChange);
    } else {
      pressedJump = false;
    }
  }
}

bool CheckGrounded() {
  Vector3 corner1 = transform.position + new Vector3();  
  Vector3 corner2 = transform.position + new Vector3();
  Vector3 corner3 = transform.position + new Vector3();
  Vector3 corner4 = transform.position + new Vector3();
}
