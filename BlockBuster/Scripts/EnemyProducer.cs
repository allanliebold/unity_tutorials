using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProducer : MonoBehaviour {
  public bool shouldSpawn;
  public Enemy[] enemyPrefabs;
  public float[] moveSpeedRange;
  public int[] healthRange;
  
  private Bounds spawnArea;
  private GameObject player;
  
  void Start() {
    spawnArea = this.GetComponent<BoxCollider>().bounds;  
    SpawnEnemies(shouldSpawn);
    InvokeRepeating("spawnEnemy", 0.5f, 1.0f);
  }
  
  public void SpawnEnemies(bool shouldSpawn) {
    if(shouldSpawn) {
      player = GameObject.FindGameObjectWithTag("Player");
    }
    this.shouldSpawn = shouldSpawn;
  }
  

}
