using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class EnemyDatabase : MonoBehaviour {
  public List<Enemy> Enemies { get; set; } = new List<Enemy>(); 
  public static EnemyDatabase Instance { get; set; }
}
