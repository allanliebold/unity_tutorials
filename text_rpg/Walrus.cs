using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Walrus : Enemy {
  void Start() {
    Health = 15;
    Strength = 8;
    Defense = 8;
    Gold = 25;
    Inventory.Add("Tusk");
  }
}
