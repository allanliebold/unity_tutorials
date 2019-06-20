using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int score = 0;
    public int currentLevel = 1;
    public int highestLevel = 5;
    
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
    
    public void ResetGame() {
        score = 0;    
        currentLevel = 1;
        SceneManager.LoadScene("Level1");
    }
    
    public void IncreaseLevel() {
        currentLevel++;
        SceneManager.LoadScene("Level" + currentLevel);
    }
}
