using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObstaclePrefabs;
    [SerializeField] private float spawnTimemin = 2f;
    [SerializeField] private float spawnTimemax = 5f;
    [SerializeField] private float obstacleSpeed = 3f;
    [SerializeField] private Animator animator;
    //[SerializeField] private obstacleSpawner obstacleSpawner;

    public float obstacleSpawnTime = 2f;
    
    private float timeUntilObstacleSpawn;

    public List<GameObject> activeObstacles;
    [SerializeField] private GameObject stageStart;

    private Transform lastLavelPartTransform;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

  
    // Update is called once per frame
    private void Update()
    {
       if(GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
        
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
          //if(is paused = 
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimemin, spawnTimemax);
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void StartSpawn()
    {
        if(stageStart != null)
        {
            Rigidbody2D obstacleRB = stageStart.GetComponent<Rigidbody2D>();
            animator.SetBool("isDying", true);

            obstacleRB.velocity = Vector2.left * obstacleSpeed;
            activeObstacles.Add(stageStart);
        }
    }
    //same thing to make bullets
    private void Spawn()
    {
        GameObject obstacleToSpawn = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];

        GameObject spawnedobstalce = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedobstalce.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
        activeObstacles.Add(spawnedobstalce);
    }

    public void pausedObstacles()
    {
        foreach(GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * 0f;
        }
    }

    public void ResumeObstacles()
    {
        foreach(GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * obstacleSpeed;
        }
    }


}
