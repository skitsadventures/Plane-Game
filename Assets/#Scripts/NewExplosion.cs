using UnityEngine;

public class NewExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // Reference to the explosion prefab
    private float explosionForce = 500;
    private float explosionRadius = 5;
    private float triggerForce = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision occurred with an object tagged "GroundLayer"
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            // Instantiate the explosion prefab at the same position as this GameObject.
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Optionally, you can also destroy this GameObject if needed.
            Destroy(gameObject);
        }
    }
}
