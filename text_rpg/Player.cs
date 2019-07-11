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
    if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0) - 1) {
      RoomIndex += Vector2.right;
    }
    if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1) - 1) {
      RoomIndex -= Vector2.down;
    }
    if (direction == 3 && RoomIndex.x > world.Dungeon.GetLength(0) - 1) {
      RoomIndex += Vector2.left;
    }
  }
  
  public void AddItem(string item) {
    TextDisplay.Instance.Log("Got item: " + item);
    Inventory.Add(item);  
  }
  
  public override void TakeDamage(int amount) {
    Debug.Log("Player took damage.");
    base.TakeDamage(amount);
  }
  
  public override void Die() {
    Debug.Log("Player died. Game over.");
    base.Die();
  }    
}

