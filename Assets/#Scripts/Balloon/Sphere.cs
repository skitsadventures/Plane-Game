using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 2f;

    private RoamArea roamArea;
    private Vector3 targetPosition;

    private void Start()
    {
        roamArea = transform.parent.GetComponent<RoamArea>();
        // Set the initial target position within the specified radius
        targetPosition = roamArea.GetRandomPosition();
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the target position has been reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set a new random target position within the specified radius
            targetPosition = roamArea.GetRandomPosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "bullet" tag
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Delete the roaming object
            Destroy(gameObject);
        }
    }
}
