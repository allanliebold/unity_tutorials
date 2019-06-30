using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using TextRPG;

public class Raccoon : Enemy {
  void Start () {
    Health = 10;  
    Strength = 5;
    Defense = 3;
    Gold = 20;
    Inventory.Add("Bandit Mask");
    Inventory.Add("Acorn");
  }
}
