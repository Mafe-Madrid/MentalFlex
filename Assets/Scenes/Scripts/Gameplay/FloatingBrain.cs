using UnityEngine;

public class FloatingBrain : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Movement Settings")]
    public float speed = 1.5f;

    private Transform currentTarget;

    private float fixedY;
    private float fixedZ;

    private bool isCalmed = false;

    private void Start()
    {
        currentTarget = pointB;

        // Keep the original Y and Z positions
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    private void Update()
    {
        if (isCalmed)
            return;

        Vector3 targetPosition = new Vector3(
            currentTarget.position.x,
            fixedY,
            fixedZ
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        if (Mathf.Abs(transform.position.x - currentTarget.position.x) < 0.05f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    public void CalmBrain(float duration)
    {
        if (!isCalmed)
        {
            StartCoroutine(CalmRoutine(duration));
        }
    }

    private System.Collections.IEnumerator CalmRoutine(float duration)
    {
        isCalmed = true;

        yield return new WaitForSeconds(duration);

        isCalmed = false;
    }
}

