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
  
  protected virtual void Awake() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
  
  protected virtual void Start() {
    powerUpState = PowerUpState.InAttractMode; 
  }
  
  protected virtual void OnTriggerEnter2D(Collider2D other) {
    PowerUpCollected(other.gameObject); 
  }
  
  protected virtual void OnTriggerEnter(Collider other) {
    PowerUpCollected(other.gameObject); 
  }
  
  protected virtual void PowerUpCollected(GameObject gameObjectCollectingPowerUp) {
    if(gameObjectCollectingPowerUp.tag != "Player") {
      return; 
    }
    
    if(powerUpState == PowerUpState.IsCollected || powerUpState == PowerUpState.IsExpiring) {
      return;  
    }
    
    powerUpState = PowerUpState.IsCollected;
    
    playerBrain = gameObjectCollectingPowerUp.GetComponent<PlayerBrain>();
    
    gameObject.transform.parent = playerBrain.gameObject.transform;
    gameObject.transform.position = playerBrain.gameObject.transform.position;
    
    PowerUpEffects();
    PowerUpPayload();
    
    foreach(GameObject go in EventSystemListeners.main.listeners) {
      ExecuteEvents.Execute<IPowerUpEvents>(go, null, (x,y) => x.OnPowerUpCollected(this, playerBrain)); 
    }
  }
}
