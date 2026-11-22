using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MovingPlatform2D : MonoBehaviour
{
    [Header("Waypoints")]

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [Header("Movement Settings")]

    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float waitAtEndpoints = 0.4f;
    [SerializeField] private bool startMovingToB = true;

    private Vector3 targetPosition;
    private Vector3 previousPosition;
    private float waitTimer;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("MovingPlatform2D: Assign both PointA and PointB.", this);
            enabled = false;
            return;
        }

        transform.position = startMovingToB ? pointA.position : pointB.position;
        targetPosition = startMovingToB ? pointB.position : pointA.position;
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (pointA == null || pointB == null)
        {
            return;
        }

        previousPosition = transform.position;

        if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.fixedDeltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
        {
            transform.position = targetPosition;
            targetPosition = (targetPosition == pointB.position) ? pointA.position : pointB.position;
            waitTimer = waitAtEndpoints;
        }
    }

    private void LateUpdate()
    {
        Vector3 delta = transform.position - previousPosition;
        if (delta.sqrMagnitude <= Mathf.Epsilon)
        {
            return;
        }

        // Move any player object currently standing on top of the platform

        if (Player == null)
        {
            return;
        }

        if (IsPlayerStandingOnPlatform(Player.transform))
        {
            Player.transform.position += delta;
        }
    }

    private Transform cachedPlayer;
    private Transform Player
    {
        get
        {
            if (cachedPlayer == null)
            {
                GameObject playerObj = GameObject.Find("Player");
                if (playerObj != null)
                {
                    cachedPlayer = playerObj.transform;
                }
            }
            return cachedPlayer;
        }
    }

    private bool IsPlayerStandingOnPlatform(Transform playerTransform)
    {
        Collider2D platformCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = playerTransform.GetComponentInChildren<Collider2D>();

        if (platformCollider == null || playerCollider == null)
        {
            return false;
        }

        // Check that player is overlapping or slightly above the top of the platform

        float platformTop = platformCollider.bounds.max.y;
        float playerBottom = playerCollider.bounds.min.y;
        bool withinX = playerCollider.bounds.max.x >= platformCollider.bounds.min.x &&
                       playerCollider.bounds.min.x <= platformCollider.bounds.max.x;
        bool nearTop = Mathf.Abs(playerBottom - platformTop) <= 0.25f || platformCollider.bounds.Intersects(playerCollider.bounds);

        return withinX && nearTop;
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawWireSphere(pointA.position, 0.2f);
            Gizmos.DrawWireSphere(pointB.position, 0.2f);
        }
    }
}