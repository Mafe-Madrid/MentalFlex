using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform currentTarget;

    private void Start()
    {
        currentTarget = pointB;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.05f)
        {
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}