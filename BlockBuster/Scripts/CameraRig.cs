using System.Collections;
using UnityEngine;

public class CameraRig : MonoBehaviour {
  public float moveSpeed;
  public GameObject target;
  
  private Transform rigTransform;
  
  void Start () {
    rigTransform = this.transform.parent;
  }
  
  void FixedUpdate () {
    if(target == null) {
      return; 
    }
  }
}
