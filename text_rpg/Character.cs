using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
  public int HP { get; set; }
  public int STR { get; set; }
  public int DEF { get; set; }
  public int GP { get; set; }
  public Vector 2 RoomIndex { get; set; }
  public List<string> Inventory {}
}
