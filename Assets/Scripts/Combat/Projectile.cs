using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void Init(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health enemyHp = other.GetComponent<Health>();
            if (enemyHp != null)
            {
                enemyHp.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}