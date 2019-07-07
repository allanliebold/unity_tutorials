using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Player : Character {
  public int Floor { get; set; }
  public Room Room { get; set; }
  World world;
    
    void Start() {
      Energy = 30;
      Attack = 10;
      Defense = 5;
      Gold = 0;
    }
  }
  
  public void AddItem(string item) {
    Inventory.Add(item);  
  }
  
  public override void TakeDamage(int amount) {
    base.TakeDamage(amount);
  }
  
  public override void Die() {
    
  }
}
