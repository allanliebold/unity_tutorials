using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG {
  public class Character : MonoBehaviour {
    public int HP { get; set; }
    public int STR { get; set; }
    public int DEF { get; set; }
    public int GP { get; set; }
    public Vector2 RoomIndex { get; set; }
    public List<string> Inventory { get; set; }
  }
  
  public virtual void TakeDamage(int amount) {
    HP -= amount;  
    if(HP <= 0) {
      Die(); 
    }
  }
  
  public virtual void Die() {
    Debug.Log("Died.");
  }
}
