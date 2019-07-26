using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Encounter : MonoBehaviour {
  [SerializeField] Player player;
  [SerializeField] Button dynamicControls;
  
  public void ResetDynamicControls() {
    foreach(Button button in dynamicControls) {
      button.interactable = false;
    }
  }
  
  public void StartCombat() {
    this.Enemy = player.Room.Enemy;
    dynamicControls[0].interactable = true;  
    dynamicControls[1].interactable = true;
  }
  
  public void StartChest() {
    dynamicControls[3].interactable = true;  
  }
  
  public void StartExit() {
    dynamicControls[4].interactable = true;  
  }
  
  public void Attack() {
    int playerDamageAmount = (int)(Random.value * (player.STR - Enemy.DEF));  
    int enemyDamageAmount = (int)(Random.value * (Enemy.STR - player.DEF));
    player.TakeDamage(enemyDamageAmount);
    Enemy.TakeDamage();
  }
}
