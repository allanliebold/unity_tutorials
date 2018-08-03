using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  
  public float acceleration;
  public float maxSpeed; 
  
  private Rigidbody rigidBody;
  private KeyCode[] inputKeys;
  private Vector3[] directionsForKeys;
  
  void Start () {
    
  }
  
  void FixedUpdate () {
    
  }
}
