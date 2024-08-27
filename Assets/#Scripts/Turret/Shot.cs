using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject muzzlePrefab;
    public float speed;
    private float life;

    Rigidbody Bullet;
    Vector3 velocity;

    void Awake()
    {
        TryGetComponent(out Bullet);
    }

    void Start()
    {
        var muzzleEffect = Instantiate(muzzlePrefab, transform.position, transform.rotation);
        Destroy(muzzleEffect, 5f);
        velocity = transform.forward * speed;
    }

    void FixedUpdate()
    {
        var displacement = velocity * Time.deltaTime;
        Bullet.MovePosition(Bullet.position + displacement);
    }

    void OnCollisionEnter(Collision other)
    {
        var hitEffect = Instantiate(hitPrefab, other.GetContact(0).point, Quaternion.identity);
        Destroy(hitEffect, 5f);
        Destroy(gameObject);
    }
    private void Update()
    {
        life += 0.1f;
        if (life > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}