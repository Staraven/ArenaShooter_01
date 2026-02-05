using UnityEngine;

public class EnemyDamageOnTouch : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float damageCooldown = 0.7f;

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timer > 0f) return;

        if (!collision.collider.CompareTag("Player")) return;

        
        Health hp = collision.gameObject.GetComponent<Health>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
            timer = damageCooldown;
        }
    }
}