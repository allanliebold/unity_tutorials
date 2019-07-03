using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class World : MonoBehaviour {
  public Room[,] Dungeon { get; set; }  
  public Vector2 Grid;
  
  public void GenerateFloor() {
    for(int x = 0; x < Grid.x; x++) {
      for(int y = 0; y < Grid.y; y++) {
        Dungeon[x,y] = new Room {
          
        };
      }
  }
}


