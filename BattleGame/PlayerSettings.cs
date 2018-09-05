using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
private Toggle toggle;
[SerializeField]
private AudioSource myAudio;

public class PlayerSettings : MonoBehaviour {
  
  public void Awake () {
    if (!PlayerPrefs.HasKey("music")) {
      PlayerPrefs.SetInt("music", 1);
      toggle.isOn = true;
      myAudio.enabled = true;
      PlayerPrefs.Save();
    } else {
      if (PlayerPrefs.GetInt("music") == 0) {
        myAudio.enabled = false;
        toggle.isOn = false;
      } else {
        myAudio.enabled = true;
        toggle.isOn = true;
      }
    }
  }
}
