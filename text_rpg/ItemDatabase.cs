using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class ItemDatabase : MonoBehaviour {
  public List<string> Items { get; set; } = new List<string>();
  public static ItemDatabase Instance { get; private set; }
}
