using UnityEngine;
using System.Collections; 

public int xIndex;
public int yIndex;

Board m_board;

public class Tile : MonoBehaviour {
  void Init(int x, int y, Board board) {
    xIndex = x;
    yIndex = y;
    m_board = board;
  }
}
