using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private void DropBomb() {
    if (bombPrefab) {
      Instantiate(bombPrefab, myTransform.position, bombPrefab.transform.rotation);  
    }
  }
}
