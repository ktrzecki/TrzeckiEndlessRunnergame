using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelgenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] ObstaclePrefabs;
    [SerializeField] private float spawnTimemin = 2f;
    [SerializeField] private float spawnTimemax = 6f;
    [SerializeField] private float obstacleSpeed = 3f;
    //[SerializeField] private obstacleSpawner obstacleSpawner;

    public float obstacleSpawnTime = 2f;
    private float timeUntilObstacleSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn = Time.deltaTime;

        if (timeUntilObstacleSpawn <= obstacleSpawnTime) 
        {
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimemin, spawnTimemax);
            timeUntilObstacleSpawn = 0f;
        }
    }
    //same thing to make bullets
    private void Spawn()
    {
        GameObject obstacleToSpawn = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];

        GameObject spawnedobstalce = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody obstacleRB = spawnedobstalce.GetComponent<Rigidbody>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
