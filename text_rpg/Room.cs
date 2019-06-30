using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Room : MonoBehaviour {
  public Chest Chest { get; set; }
  public Enemy Enemy { get; set; }
  public bool Exit { get; set; }
  public bool Empty { get; set; }
}

public Room () {
  int roll = Random.Range(0, 30);
  if(roll > 0 && roll < 6) {
    
  }
  
}
