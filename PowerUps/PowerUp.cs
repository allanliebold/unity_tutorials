using UnityEngine;
using UnityEngine.EventSystems;

public class PowerUp : MonoBehaviour {
  public string powerUpName;
  public string powerUpExplanation;
  public string powerUpQuote;
  
  public bool expiresImmediately;
  public GameObject specialEffect;
  public AudioClip soundEffect;
  
  protected PlayerBrain playerBrain;
  protected SpriteRenderer spriteRenderer;
  
  protected enum PowerUpState {
    InAttractMode,
    IsCollected,
    IsExpiring
  }
  
  protected PowerUpState powerUpState;
  
}
