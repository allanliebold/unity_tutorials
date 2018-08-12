using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private void DropBomb() {
    if (bombPrefab) {
      Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x), 
                  bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)), 
                  bombPrefab.transform.rotation);
    }
  }
}
