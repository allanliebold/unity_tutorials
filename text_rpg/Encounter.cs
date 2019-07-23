using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Encounter : MonoBehaviour {
  [SerializeField] Player player;
  [SerializeField] Button dynamicControls;
  
  public void ResetDynamicControls() {
    foreach(Button button in dynamicControls) {
      button.active = false;
    }
  }
  
  public void StartCombat() {
    dynamicControls[0].active = true;  
  }
}
