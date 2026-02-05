using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private int maxAlive = 20;
    [SerializeField] private float spawnRadius = 10f;
    
    [SerializeField] private float minX = -14.0f;
    [SerializeField] private float maxX =  14.0f;
    [SerializeField] private float minY = -8.0f;
    [SerializeField] private float maxY =  8.0f;


    private float timer;
    private Transform player;
    private int aliveCount;
    
    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null) return;
        if (aliveCount >= maxAlive) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Spawn();
            timer = spawnInterval;
        }
    }

    private void Spawn()
    {
        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 pos = player.position + (Vector3)offset;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
        aliveCount++;
    }


    public void NotifyEnemyDied()
    {
        aliveCount = Mathf.Max(0, aliveCount - 1);
    }
}
