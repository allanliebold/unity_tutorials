using System.Collection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextRPG;

public class TextDisplay : MonoBehaviour {
  [SerializeField] Text textLog;  
  public static TextDisplay Instance { get; set; }
  
  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(this.gameObject); 
    } else {
      Instance = this;  
    }
  }
  
}
