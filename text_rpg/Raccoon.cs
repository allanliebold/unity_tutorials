using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using TextRPG;

public class Raccoon : Enemy {
  void Start () {
    HP = 10;  
    STR = 5;
    DEF = 3;
    GP = 20;
    Inventory.Add("Bandit Mask");
    Inventory.Add("Acorn");
  }
}
