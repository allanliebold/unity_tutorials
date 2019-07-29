
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class Enemy : Character {
    public override void TakeDamage(int amount) {
      base.TakeDamage(amount);
    }
    
    public override void Die() {
        Debug.Log("Enemy died.");   
    }
}
