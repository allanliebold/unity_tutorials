using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class ItemDatabase : MonoBehaviour {
  public List<string> Items { get; set; } = new List<string>();
  public static ItemDatabase Instance { get; private set; }
  
  private void Awake() {
    if(Instance != null && Instance != this) {
      Destroy(this.gameObject);  
    } else {
      Instance = this; 
    }
    
    Items.Add("Shield");
    Items.Add("Boots");
    Items.Add("Mirror");
    Items.Add("Ring");
    Items.Add("Bow");
    Items.Add("Map");
    Items.Add("Gem");
  }
  
  public Item GetRandomItem() {
    return Items[Random.Range(0, Items.Count)];
  }
}
