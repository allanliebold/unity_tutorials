using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG {
  public class Player : Character {
    
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