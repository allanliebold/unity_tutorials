using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public GameObject explosionPrefab;

public class Bomb : MonoBehaviour {
  void Start() {
    Invoke("Explode", 3f);
  }
  
  void Update() {
    
  }
  
  void Explode() {
    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    
    StartCoroutine(CreateExplosions(Vector3.forward));
    StartCoroutine(CreateExplosions(Vector3.right));
    
    GetComponent<MeshRenderer>().enabled = false;
    transform.Find("Collider").gameObject.SetActive(false);
    Destroy(gameObject, .3f);
  }
  
  private IEnumerator CreateExplosions(Vector3 direction) {
    return null;
  }
}
