using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [Range (1, 2)]
  public int playerNumber = 1; 
  public float moveSpeed = 5f;
  public bool canDropBombs = true;
  public bool canMove = true;
  private int bombs = 2;
  public GameObject bombPrefab;
  
  private Rigidbody rigidBody;
  private Transform myTransform;
  private Animator animator;
  
  void Start() {
    rigidBody = GetComponent<Rigidbody>();
    myTransform = transform;
    animator = myTransform.Find("PlayerModel").GetComponent<Animator>();
  }
  
  void Update() {
    UpdateMovement(); 
  }
  
  private void UpdateMovement() {
    animator.SetBool("Walking", false);
    if(!canMove) {
      return; 
    }
    
    if(playerNumber == 1) {
      UpdatePlayer1Movement(); 
    } else {
      UpdatePlayer2Movement();
    }
  }
  
  private void UpdatePlayer1Movement() {
    if(Input.GetKey(KeyCode.W)) {
       
    }
       
    if(Input.GetKey(KeyCode.A)) {
      
    }
       
    if(Input.GetKey(KeyCode.S)) {
      
    }
       
    if(Input.GetKey(KeyCode.D)) {
      
    }
    
    if(canDropBombs && Input.GetKeyDown(KeyCode.Space) {
      DropBomb(); 
    }
  }
  
  private void DropBomb() {
    if (bombPrefab) {
      Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x), 
                  bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)), 
                  bombPrefab.transform.rotation);
    }
    
  }
}
