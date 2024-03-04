using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] CollectablePrefabs;
    [SerializeField] private float spawnTimemin = 10f;
    [SerializeField] private float spawnTimemax = 18f;
    [SerializeField] private float collectableSpeed = 3f;
 

    public float collectableSpawnTime = 3f;

    private float timeUntilCollectableSpawn;

    public List<GameObject> activeCollectables;
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
        timeUntilCollectableSpawn += Time.deltaTime;

        if (timeUntilCollectableSpawn >= collectableSpawnTime)
        {
            Spawn();
            collectableSpawnTime = Random.Range(spawnTimemin, spawnTimemax);
            timeUntilCollectableSpawn = 0f;
        }
    }

    private void StartSpawn()
    {
        if (stageStart != null)
        {
            Rigidbody2D collectableRB = stageStart.GetComponent<Rigidbody2D>();

            collectableRB.velocity = Vector2.left * collectableSpeed;
            activeCollectables.Add(stageStart);
        }
    }
    //same thing to make bullets
    private void Spawn()
    {
        GameObject collectableToSpawn = CollectablePrefabs[Random.Range(0, CollectablePrefabs.Length)];

        GameObject spawnedcollectable = Instantiate(collectableToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D collectableRB = spawnedcollectable.GetComponent<Rigidbody2D>();
        collectableRB.velocity = Vector2.left * collectableSpeed;
        activeCollectables.Add(spawnedcollectable);
    }

    public void pausedCollectables()
    {
        foreach (GameObject collectable in activeCollectables)
        {
            Rigidbody2D collectableRB = collectable.GetComponent<Rigidbody2D>();
            collectableRB.velocity = Vector2.left * 0f;
        }
    }

    public void ResumeCollectables()
    {
        foreach (GameObject collectable in activeCollectables)
        {
            Rigidbody2D collectableRB = collectable.GetComponent<Rigidbody2D>();
            collectableRB.velocity = Vector2.left * collectableSpeed;
        }
    }
}
