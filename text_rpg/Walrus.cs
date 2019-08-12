using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Walrus : Enemy {
  void Start() {
    HP = 20;
    STR = 10;
    DEF = 8;
    GP = 20;
    Inventory.Add("Tusk");
    Inventory.Add("Blubber");
  }
}
