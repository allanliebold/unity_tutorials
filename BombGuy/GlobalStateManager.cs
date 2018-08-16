using UnityEngine;
using System.Collections;

public class GlobalStateManager : MonoBehaviour {
  private int deadPlayers = 0;
  private int deadPlayerNumber = -1;
  
  public void PlayerDied(int playerNumber) {
    deadPlayers++;
  }
}
