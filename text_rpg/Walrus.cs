using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Walrus : Enemy {
  void Start() {
    HP = 15;
    STR = 8;
    DEF = 8;
    GP = 25;
    Inventory.Add("Tusk");
  }
}
