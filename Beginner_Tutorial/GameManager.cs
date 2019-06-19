using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int score = 0;
    public int currentLevel = 1;
    
    public static GameManager instance;
    
    void Awake() {
        if(instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);    
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    public void IncreaseScore(int amount) {
        score += amount;  
    }
}
