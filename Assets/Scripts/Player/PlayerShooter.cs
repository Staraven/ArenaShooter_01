using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootInterval = 0.35f;
    [SerializeField] private float projectileOffset = 0.6f;

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            timer = shootInterval;
        }
    }

    private void Shoot()
    {
        Vector2 dir = Vector2.up;

        Vector3 spawnPos = transform.position + (Vector3)(dir * projectileOffset);
        GameObject bullet = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        bullet.GetComponent<Projectile>().Init(dir);
    }
}