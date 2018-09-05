using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
private Toggle toggle;
[SerializeField]
private AudioSource myAudio;

public void Awake () {
  if (!PlayerPrefs.HasKey("music")) {
    PlayerPrefs.SetInt("music", 1);
    toggle.isOn = true;
  }
}
