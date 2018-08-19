using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBrain : MonoBehaviour, IMainGameEvents
{
    public float speed = 2.2f;
    public int damageFromEnemyContact = 11;
    public AudioClip soundEffectEnemyContact;
    public GameObject particleContactPrefab;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private GameObject particleContactInstance;
    private ParticleSystem particleSystemContactInstance;
    
    private int playerHitPoints;
    private float speedOriginal;
    private bool isPlayerInvulnerable;
    private float horizSpeed;
    private float vertSpeed;

    void IMainGameEvents.OnGameWon ()
    {
        rigidBody.simulated = false;
    }

    void IMainGameEvents.OnGameLost ()
    {
        rigidBody.simulated = false;
        spriteRenderer.color = Color.grey;
    }

    private void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    void Start ()
    {
        playerHitPoints = 100;
    }

    public void SetHealthAdjustment (int adjustmentAmount)
    {
        playerHitPoints += adjustmentAmount;

        if (playerHitPoints > 100)
        {
            playerHitPoints = 100;
        }

        SendPlayerHurtMessages ();
    }

    private void SendPlayerHurtMessages ()
    {
        foreach (GameObject go in EventSystemListeners.main.listeners)
        {
            ExecuteEvents.Execute<IPlayerEvents> (go, null, (x, y) => x.OnPlayerHurt (playerHitPoints));
        }
    }

    public void SetSpeedBoostOn (float speedMultiplier)
    {
        speedOriginal = speed;
        speed *= speedMultiplier;
    }

    public void SetSpeedBoostOff ()
    {
        speed = speedOriginal;
    }

    public void SetInvulnerability (bool isInvulnerabilityOn)
    {
        isPlayerInvulnerable = isInvulnerabilityOn;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            foreach (GameObject go in EventSystemListeners.main.listeners)
            {
                ExecuteEvents.Execute<IPlayerEvents> (go, null, (x, y) => x.OnPlayerReachedExit (collision.gameObject));
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!isPlayerInvulnerable)
            {
                if (soundEffectEnemyContact != null)
                {
                    MainGameController.main.PlaySound (soundEffectEnemyContact);
                }

                // Some small collision particles
                SpawnCollisionParticles (collision.transform.position, collision.transform.rotation);

                SetHealthAdjustment (-damageFromEnemyContact);
            }
        }
    }

    private void SpawnCollisionParticles (Vector3 pos, Quaternion rot)
    {
        // Just one system that we keep re-using (if it is in use we don't spawn any particles)
        if (particleContactPrefab != null)
        {
            if (particleContactInstance == null)
            {
                // First time usage
                particleContactInstance = Instantiate (particleContactPrefab, pos, rot, transform);
                particleSystemContactInstance = particleContactInstance.GetComponent<ParticleSystem> ();
            } else
            {
                if (!particleSystemContactInstance.IsAlive ())
                {
                    // Reuse existing particle system
                    particleContactInstance.transform.SetPositionAndRotation (pos, rot);
                    particleSystemContactInstance.Play ();
                }
            }
        }
    }

    // update is called once per frame
    private void Update ()
    {
        horizSpeed = Input.GetAxis ("Horizontal") * speed;
        vertSpeed = Input.GetAxis ("Vertical") * speed;
    }

    private void FixedUpdate ()
    {
        // Movement
        rigidBody.velocity = new Vector2 (horizSpeed, vertSpeed);
    }
}