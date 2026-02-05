using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 3;
    [SerializeField] private bool notifySpawner;

    public int CurrentHp { get; private set; }

    private EnemySpawner spawner;

    private void Awake()
    {
        CurrentHp = maxHp;

        if (notifySpawner)
        {
            spawner = Object.FindFirstObjectByType<EnemySpawner>();
        }
    }

    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;

        if (CurrentHp <= 0)
        {
            if (notifySpawner && spawner != null)
                spawner.NotifyEnemyDied();

            Destroy(gameObject);
        }
    }
}