using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour, IPlayerEvents, IPowerUpEvents
{
    public static MainGameController main;

    [Tooltip ("UI text to use for messages to player about pickups and gameover")]
    public Text uiText;
    [Tooltip ("UI subtext for additional messages to player")]
    public Text uiSubtext;
    [Tooltip ("UI canvas group for fading")]
    public CanvasGroup uiCanvasGroup;
    [Tooltip ("UI texts display this long after first appearing")]
    public float uiTextDisplayDuration = 5f;
    [Tooltip ("UI text to show whole list of active power ups")]
    public Text uiTextActivePowerUps;
    
    public AudioClip soundEffectWin;
    public AudioClip soundEffectLose;
    public GameObject specialEffectWin;

    private float uiTextDisplayTimer;
    private AudioSource audioSource;
    private List<PowerUp> activePowerUps;

    private enum MainGameState
    {
        Idle,
        Playing,
        GameOver
    }

    private MainGameState mainGameState = MainGameState.Idle;

    void IPlayerEvents.OnPlayerHurt (int newHealth)
    {
        if (mainGameState == MainGameState.GameOver) {
            return;
        }

        if (newHealth <= 0)
        {
            if (soundEffectLose != null)
            {
                PlaySound (soundEffectLose);
            }
            GameOverLose ();
        }
    }

    void IPlayerEvents.OnPlayerReachedExit (GameObject exit)
    {
        if (mainGameState == MainGameState.GameOver)
        {
            return;
        }

        if (soundEffectWin != null)
        {
            PlaySound (soundEffectWin);
        }

        if (specialEffectWin != null)
        {
            Instantiate (specialEffectWin, exit.transform.position, exit.transform.rotation, exit.transform);
        }

        GameOverWin ();
    }

    void IPowerUpEvents.OnPowerUpCollected (PowerUp powerUp, PlayerBrain player)
    {
        if (!powerUp.expiresImmediately) {
            activePowerUps.Add (powerUp);
            UpdateActivePowerUpUi ();
        }

        uiText.text = powerUp.powerUpExplanation;
        uiSubtext.text = powerUp.powerUpQuote;
        uiTextDisplayTimer = uiTextDisplayDuration;
    }

    void IPowerUpEvents.OnPowerUpExpired (PowerUp powerUp, PlayerBrain player)
    {
        activePowerUps.Remove (powerUp);
        UpdateActivePowerUpUi ();
    }

    private void UpdateActivePowerUpUi ()
    {
        uiTextActivePowerUps.text = "Active Power Ups";

        if (activePowerUps == null || activePowerUps.Count == 0)
        {
            uiTextActivePowerUps.text += "\nNone";
            return;
        }

        foreach (PowerUp powerUp in activePowerUps)
        {
            uiTextActivePowerUps.text += "\n" + powerUp.powerUpName;
        }
    }

    private void Awake ()
    {
        if (main == null)
        {
            main = this;
            audioSource = gameObject.GetComponent<AudioSource> ();
            activePowerUps = new List<PowerUp> ();
        } else
        {
            Debug.LogWarning ("GameController re-creation attempted, destroying the new one");
            Destroy (gameObject);
        }
    }

    void Start ()
    {
        mainGameState = MainGameState.Playing;
        UnityEngine.Random.InitState ((int)System.DateTime.Now.Ticks);
        uiTextDisplayTimer = uiTextDisplayDuration * 3; // leave instructions on screen for longer
        UpdateActivePowerUpUi ();
    }

    void Update ()
    {
        if (mainGameState == MainGameState.GameOver)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                ReloadLevel ();
            }
        }

        uiTextDisplayTimer -= Time.deltaTime;
        if (uiTextDisplayTimer < 1)
        {
            uiCanvasGroup.alpha = uiTextDisplayTimer;
        } else if (uiTextDisplayTimer < 0)
        {
            uiCanvasGroup.alpha = 0f;
        } else
        {
            uiCanvasGroup.alpha = 1f;
        }
    }

    public void ReloadLevel ()
    {
        SceneManager.LoadSceneAsync (0, LoadSceneMode.Single);
    }

    public void PlaySound (AudioClip audioClip)
    {
        audioSource.PlayOneShot (audioClip);
    }

    private void GameOverLose ()
    {
        mainGameState = MainGameState.GameOver;
      
        uiText.text = "GAME OVER";
        uiSubtext.text = "Press Space to Restart";
        uiTextDisplayTimer = Mathf.Infinity;

        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IMainGameEvents> (go, null, (x, y) => x.OnGameLost ());
        }
    }

    private void GameOverWin ()
    {
        mainGameState = MainGameState.GameOver;
      
        uiText.text;
        uiText.text = "LEVEL COMPLETE";
        uiSubtext.text = "Press Space to Restart";
        uiTextDisplayTimer = Mathf.Infinity;  
    
        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IMainGameEvents> (go, null, (x, y) => x.OnGameWon ());
        }
    }
}
