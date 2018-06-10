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
    StartCoroutine(MoveRoutine(new Vector3(destX, destY, 0), timeToMove));
  }
  
  IEnumerator MoveRoutine(Vector3 destination, float timeToMove) {
    Vector3 startPosition = transform.position;
    bool reachedDestination = false;
    float elapsedTime = 0f;
    while (!reachedDestination) {
      yield return null;
    }
  }
}
