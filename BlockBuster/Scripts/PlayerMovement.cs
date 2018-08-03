using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  
  public float acceleration;
  public float maxSpeed; 
  
  private Rigidbody rigidBody;
  private KeyCode[] inputKeys;
  private Vector3[] directionsForKeys;
  
  void Start () {
    inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
  }
  
  void FixedUpdate () {
    
  }
}
