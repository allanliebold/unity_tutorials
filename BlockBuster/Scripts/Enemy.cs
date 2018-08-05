using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  public float moveSpeed;
  public int health;
  public int damage;
  public Transform targetTransform;
  
  void FixedUpdate() {
    if(targetTransform != null) {
      this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
    }
  }
  
  public void TakeDamage(int damage) {
    health -= damage;
    if(health <= 0) {
      Destroy(this.gameObject); 
    }
  }
}
