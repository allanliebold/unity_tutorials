using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D> ();  
  }
  
  void FixedUpdate () 
  {
     float moveHorizontal = Input.GetAxis ("Horizontal");
     float moveVertical = Input.GetAxis ("Vertical");
  }
}
