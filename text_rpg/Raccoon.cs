using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using TextRPG;

public class Raccoon : Enemy {
  void Start () {
    HP = 8;  
    STR = 3;
    DEF = 2;
    GP = 4;
    Inventory.Add("Bandit Mask");
    Inventory.Add("Acorn");
  }
}
