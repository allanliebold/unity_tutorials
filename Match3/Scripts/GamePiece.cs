using UnityEngine;
using System.Collections;

public class GamePiece : MonoBehaviour {
  public int xIndex;
  public int yIndex;
  bool m_isMoving = false;
  
  public InterpType interpolation;
  
  public enum InterpType {
    Linear,
    EaseOut,
    EaseIn,
    SmoothStep,
    SmootherStep
  }
  
  void Update() {
    /*
    if(Input.GetKeyDown(KeyCode.RightArrow)) {
      Move((int)transform.position.x + 1, (int)transform.position.y, 0.5f);
    }
    
    if(Input.GetKeyDown(KeyCode.LeftArrow)) {
      Move((int)transform.position.x - 1, (int)transform.position.y, 0.5f);
    }
    */
  }
  
  public void Init(Board board) {
    m_board = board;
  }

  public void SetCoord (int x, int y) {
    xIndex = x;
    yIndex = y;
  }
  
  public void Move (int destX, int destY, float timeToMove) {
    if(!m_isMoving) {
      StartCoroutine(MoveRoutine(new Vector3(destX, destY, 0), timeToMove));
    }
  }
  
  IEnumerator MoveRoutine(Vector3 destination, float timeToMove) {
    Vector3 startPosition = transform.position;
    bool reachedDestination = false;
    float elapsedTime = 0f;
    m_isMoving = true;
    
    while (!reachedDestination) {
      // do something now
      if (Vector3.Distance(transform.position, destination) < 0.01f) {
        reachedDestination = true; 
        if (m_board != null) {
          m_board.PlaceGamePiece(this, (int) destination.x, (int) destination.y);
        }
        
      //  transform.position = destination;
      //  SetCoord((int)destination.x, (int)destination.y);
        break;
      }
      
      elapsedTime += Time.deltaTime;
      float t = Mathf.Clamp(elapsedTime / timeToMove, 0f, 1f);
      
      switch(interpolation) {
        case InterpType.Linear:
          break;
        case InterpType.EaseOut:
          break;
        case InterpType.EaseIn:
          break;
        case InterpType.SmoothStep:
          break;
        case InterpType.SmootherStep:
          break;
      }
      //t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
      //t = t * t;
      t = t * t * t * (t * (t * 6 - 15) + 10);
      transform.position = Vector3.Lerp(startPosition, destination, t);
      
      // wait until next frame
      yield return null;
    }    
    m_isMoving = false;
  }
}
