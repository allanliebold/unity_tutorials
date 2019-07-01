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

public Chest() {
  goldAmounts = [5, 10, 15, 20, 50, 100];
  
  if(Random.Range(0, 7) == 2) {
    Trap = true; 
  } else if (Random.Range(0, 5) == 2) {
    Heal = true;  
  } else if (Random.Range(0, 5) == 2) {
    Enemy = EnemyDatabase.Instance.GetRandomEnemy(); 
  } else {
    int itemToAdd = Random.Range(0, ItemDatabase.Instance.Items.Count); 
    Item = ItemDatabase.Instance.Items[itemToAdd];
    Gold = goldAmounts[(int)Random.Range(0, goldAmounts.Count)];
  }
}
