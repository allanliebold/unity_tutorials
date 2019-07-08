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
    GP = 0;
    Inventory = new List<string>();
    RoomIndex = new Vector2(2, 2);
    world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y].Empty = true;
    AddItem("Pouch");
    }
  }

  public void Move(int direction) {
    if (this.Room.Enemy) {
      return; 
    }
    
    if (direction == 0 && RoomIndex.y > 0) {
      RoomIndex -= Vector2.up; 
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
    console.log("Player died.");  
  }    
}

