using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using TextRPG;

public class Raccoon : Enemy {
  void Start () {
    HP = 8;  
    STR = 4;
    DEF = 2;
    GP = 4;
    Inventory.Add("Acorn");
    Inventory.Add("Stick");
  }
}
