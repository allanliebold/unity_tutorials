using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Player : Character {
  public int Floor { get; set; }
  public Room Room { get; set; }
  [SerializeField] World world;
    
  void Start() {
    HP = 30;
    STR = 10;
    DEF = 5;
    Gold = 0;
    }
  }
  
  public void AddItem(string item) {
    TextDisplay.Instance.Log("Got item: " + item);
    Inventory.Add(item);  
  }
  
  public override void TakeDamage(int amount) {
    base.TakeDamage(amount);
  }
  
  public override void Die() {
    
  }    
}

