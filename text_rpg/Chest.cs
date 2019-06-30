using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Chest : MonoBehaviour {
  public string Item { get; set; }
  public int Gold { get; set; }
  public bool Trap { get; set; }
  public bool Heal { get; set; }
  public Enemy Enemy { get; set; } 
}
