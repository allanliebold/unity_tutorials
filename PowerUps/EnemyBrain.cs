using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public float speed;

    [Tooltip ("Radius of circle around current pos where next waypoint will be")]
    public float nextWaypointRadius;

    [Tooltip ("If this close to waypoint, then deemed to be AT the waypoint")]
    public float closeEnoughToWaypoint;

    [Tooltip ("Minimum time delay between movements")]
    public float minMovementTime;

    [Tooltip ("Max time allowed to reach destination. If this is exceeded a new WP is chosen")]
    public float maxTimeToDestination;

    private float timeToDestinationTimer;
    private Vector2 nextWaypoint;
    private float moveTimer;
    private Rigidbody2D rigidBody;

    private MovementState movementState = MovementState.Idle;

    private enum MovementState
    {
        Idle,
        Moving,
    }

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D> ();

        movementState = MovementState.Idle;
        timeToDestinationTimer = maxTimeToDestination;
    }

    private void GetNewWaypoint() {
        Vector2 currentPos = new Vector2 (this.transform.position.x, this.transform.position.y);
        nextWaypoint = currentPos + UnityEngine.Random.insideUnitCircle.normalized * nextWaypointRadius;
    }

    void Start ()
    {

    }

    void Update ()
    {

    }

    void FixedUpdate ()
    {
        timeToDestinationTimer -= Time.fixedDeltaTime;
        switch (movementState)
        {
        case MovementState.Idle:
            break;

        case MovementState.Moving:
            if (timeToDestinationTimer < 0)
            {
                movementState = MovementState.Idle;
                timeToDestinationTimer = maxTimeToDestination;
            }
            break;

        default:
            break;
        }
        
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
