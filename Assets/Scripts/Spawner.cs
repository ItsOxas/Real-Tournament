using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent onWaveStarted;
    public UnityEvent onWaveEnded;

    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> EnemyCount;

    [Range(1,5)] public float interval = 2f;
    [Range(1, 10)] public float waveInterval = 10f;
    public int enemiesLeft;


    async void Start()
    {
        foreach (var count in EnemyCount)
        {
            onWaveStarted.Invoke();
            enemiesLeft = count;
            while (enemiesLeft > 0)
            {
                await new WaitForSeconds(interval);
                Spawn();
                enemiesLeft--;
            }
        }
        onWaveEnded.Invoke();
        await new WaitForSeconds(waveInterval);
    }
    
    void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
