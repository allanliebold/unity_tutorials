using UnityEngine;
using System.Collections;

public class GamePiece : MonoBehaviour {

  public int xIndex;
  public int yIndex;

  public void SetCoord (int x, int y) {
    xIndex = x;
    yIndex = y;
  }
  
  public void Move (int destX, int destY, float timeToMove) {
    
  }
}
