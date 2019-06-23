using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG {
  public int Energy { get; set; }
  public int Attack { get; set; }
  public int Defense { get; set; }             
  public Gold { get; set; }
  
  public virtual void TakeDamage(int amount) {
    Energy -= amount;
    if(Energy <= 0) {
      
    }
  }
}
