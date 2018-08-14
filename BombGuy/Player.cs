using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  [Range (1, 2)]
  public int playerNumber = 1; 
  
  private void DropBomb() {
    if (bombPrefab) {
      Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x), 
                  bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)), 
                  bombPrefab.transform.rotation);
    }
    
  }
}
