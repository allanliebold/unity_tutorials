using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public float speed;

    [Tooltip ("Radius of circle around current pos where next waypoint will be")]
    public float nextWaypointRadius;

    [Tooltip ("If this close to waypoint, then deemed to be AT the waypoint")]
    public float closeEnoughToWaypoint;

    /// <summary>
    /// Minimum time delay between movements (will sit at rest waiting)
    /// </summary>
    [Tooltip ("Minimum time delay between movements")]
    public float minMovementTime;

    /// <summary>
    /// Max time allowed to reach destination. If this is exceeded a new WP is chosen
    /// </summary>
    [Tooltip ("Max time allowed to reach destination. If this is exceeded a new WP is chosen")]
    public float maxTimeToDestination;

    private float timeToDestinationTimer;
    private Vector2 nextWaypoint;
    private float moveTimer;
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Internal record of movement state
    /// </summary>
    private MovementState movementState = MovementState.Idle;

    private enum MovementState
    {
        Idle,
        Moving,
    }

    private void Awake ()
    {
        // Refs
        rigidBody = GetComponent<Rigidbody2D> ();

        // Ready to go
        movementState = MovementState.Idle;
        timeToDestinationTimer = maxTimeToDestination;
    }

    private void GetNewWaypoint ()
    {
        Vector2 currentPos = new Vector2 (this.transform.position.x, this.transform.position.y);
        nextWaypoint = currentPos + UnityEngine.Random.insideUnitCircle.normalized * nextWaypointRadius;
    }

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    void FixedUpdate ()
    {
        //------------------------------------------------------------------------------------------
        // Execute every tick
        //------------------------------------------------------------------------------------------
        timeToDestinationTimer -= Time.fixedDeltaTime;
        switch (movementState)
        {
        case MovementState.Idle:
            break;

        case MovementState.Moving:
            // If it has taken too long to get to destination, then lets choose a new WP
            if (timeToDestinationTimer < 0)
            {
                movementState = MovementState.Idle;
                timeToDestinationTimer = maxTimeToDestination;
            }
            break;

        default:
            break;
        }

        //------------------------------------------------------------------------------------------
        // Only execute once per movement, and only when stationary
        //------------------------------------------------------------------------------------------
        moveTimer -= Time.fixedDeltaTime;
        if (moveTimer < 0 && rigidBody.velocity.magnitude < 0.1f)
        {
            switch (movementState)
            {
            case MovementState.Idle:
                GetNewWaypoint ();
                movementState = MovementState.Moving;
                break;

            case MovementState.Moving:
                Vector2 currentPos = new Vector2 (this.transform.position.x, this.transform.position.y);
                Vector2 distVect2 = currentPos - nextWaypoint;
                float dist = distVect2.magnitude;
                if (dist < closeEnoughToWaypoint)
                {
                    movementState = MovementState.Idle;
                }

                Vector3 desiredDir = nextWaypoint - currentPos;
                desiredDir.Normalize ();
                rigidBody.AddForce (desiredDir * speed);
                break;
            }
        }
    }
}
