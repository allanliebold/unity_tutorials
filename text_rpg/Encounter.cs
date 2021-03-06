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
  
  public void StartBattle() {
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
    int playerAttackAmount = (int)(Random.value * (player.STR - Enemy.DEF));  
    int enemyAttackAmount = (int)(Random.value * (Enemy.STR - player.DEF));
    
    Instance.Log("Player attacked for " + playerAttackAmount + " damage.");
    Enemy.TakeDamage(playerAttackAmount);    
    
    Instance.Log("Enemy attacked. Player took " + enemyAttackAmount + " damage.");
    player.TakeDamage(enemyAttackAmount);
  }
  
}
