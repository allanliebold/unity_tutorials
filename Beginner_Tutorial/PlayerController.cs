using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  
  public float walkSpeed = 5;
  public float jumpSpeed = 5;
  
  Rigidbody rb;
  
  void Start () {
    
  }
  
  void Update () {
    float hAxis = Input.GetAxis("Horizontal");
    float vAxis = Input.GetAxis("Vertical");
    
    Vector3 movement = new Vector3();
  }
}
