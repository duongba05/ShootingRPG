using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public GameObject[] enemys;
    public Transform[] spawnPoints;
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time+timeBetweenSpawns;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            int randomEnemy = Random.Range(0, enemys.Length);
            Instantiate(enemys[randomEnemy],randomSpawnPoint.position,Quaternion.identity);
        }
    }
}
