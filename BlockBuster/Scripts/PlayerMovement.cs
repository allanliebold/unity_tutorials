using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  
  public float acceleration;
  public float maxSpeed; 
  public int health;
  
  private Rigidbody rigidBody;
  private KeyCode[] inputKeys;
  private Vector3[] directionsForKeys;
  
  void Start () {
    inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
    rigidBody = GetComponent<Rgidibody> ();
  }
  
  void FixedUpdate () {
    for (int i = 0; i < inputKeys.length; i++) {
      var key = inputKeys[i];
      if (Input.GetKey(key)) {
        Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
        movePlayer(movement);
      }
    }
  }
  
  void movePlayer(Vector3 movement) {
    if (rigidBody.velocity.magnitude * acceleration > maxSpeed) {
      rigidBody.AddForce (movement * -1); 
    } else {
      rigidBody.AddForce (movement);  
    }
  }
  
  void collidedWithEnemy(Enemy enemy) {
    if(health <= 0) {
      enemy.Attack(this);
    }
  }
  
  void OnCollisionEnter (Collision col) {
    Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
    if (enemy) {
      collidedWithEnemy(enemy);
    }
  }
}
