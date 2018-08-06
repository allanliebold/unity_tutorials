using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public float speed;
  public int damage;
  
  Vector3 shootDirection;
  
  void FixedUpdate() {
    this.transform.Translate(shootDirection * speed, Space.World);
  }
  
  public void FireProjectile(Ray shootRay) {
    
  }
}
