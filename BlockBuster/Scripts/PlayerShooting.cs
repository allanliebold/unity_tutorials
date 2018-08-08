using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
  public Projectile projectilePrefab;
  public LayerMask mask;
  
  void shoot (RaycastHit hit) {
    var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
    var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);
    var direction = pointAboveFloor - transform.position;
    var shootRay = new Ray(this.transform.position, direction);
    
    Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
  }
}
