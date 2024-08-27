using UnityEngine;

public class RoamArea : MonoBehaviour
{
    public float radius = 5f;

    private void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the roaming radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public Vector3 GetRandomPosition()
    {
        // Generate a random point on the x-z plane within the specified radius
        Vector2 randomPoint = Random.insideUnitCircle * radius;

        // Set the y-coordinate to be the same as the current object's position
        Vector3 targetPos = new Vector3(randomPoint.x, transform.position.y, randomPoint.y);

        return transform.position + targetPos;
    }
}
