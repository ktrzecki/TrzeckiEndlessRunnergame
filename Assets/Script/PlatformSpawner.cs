using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] PlatformPrefabs;
    [SerializeField] private float spawnTimemin = 4f;
    [SerializeField] private float spawnTimemax = 7f;
    [SerializeField] private float platformSpeed = 3f;
    

    public float platformSpawnTime = 4f;

    private float timeUntilPlatformSpawn;

    public List<GameObject> activePlatforms;
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
        if (GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }

    }

    private void SpawnLoop()
    {
        timeUntilPlatformSpawn += Time.deltaTime;

        if (timeUntilPlatformSpawn >= platformSpawnTime)
        {
            Spawn();
            platformSpawnTime = Random.Range(spawnTimemin, spawnTimemax);
            timeUntilPlatformSpawn = 0f;
        }
    }

    private void StartSpawn()
    {
        if (stageStart != null)
        {
            Rigidbody2D platformRB = stageStart.GetComponent<Rigidbody2D>();

            platformRB.velocity = Vector2.left * platformSpeed;
            activePlatforms.Add(stageStart);
        }
    }
    //same thing to make bullets
    private void Spawn()
    {
        GameObject platformToSpawn = PlatformPrefabs[Random.Range(0, PlatformPrefabs.Length)];

        GameObject spawnedplatform = Instantiate(platformToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D platformRB = spawnedplatform.GetComponent<Rigidbody2D>();
        platformRB.velocity = Vector2.left * platformSpeed;
        activePlatforms.Add(spawnedplatform);
    }

    public void pausedPlatforms()
    {
        foreach (GameObject platform in activePlatforms)
        {
            Rigidbody2D platformRB = platform.GetComponent<Rigidbody2D>();
            platformRB.velocity = Vector2.left * 0f;
        }
    }

    public void ResumePlatforms()
    {
        foreach (GameObject platform in activePlatforms)
        {
            Rigidbody2D platformRB = platform.GetComponent<Rigidbody2D>();
            platformRB.velocity = Vector2.left * platformSpeed;
        }
    }
}
