using System.Collection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextRPG;

public class TextDisplay : MonoBehaviour { 
  public static TextDisplay Instance { get; set; }
  public static ActionDisplay Instance { get; set; };
  
  [SerializeField] Text logText; 
   
  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(this.gameObject); 
    } else {
      Instance = this;  
    }
  }
    
  public void Log(string text) {
    logText.text += text;
  }
}
