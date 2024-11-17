using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject[] Obstacles;
    public float basicSpawnRate = 20;
    private float spawnRate = 20;
    public float spawnRateOffset = 10;
    private float timer = 0;
    public float obstacleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        SetSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPlaying)
        {
            return;
        }

        if (timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            SpawnObstacle();
            SetSpawnRate();
            timer = 0;
        }
    }

    void SetSpawnRate()
    {
        spawnRate = basicSpawnRate + Random.Range(-(spawnRateOffset), spawnRateOffset);
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, Obstacles.Length);

        GameObject spawnedObstacle = Instantiate(Obstacles[randomIndex], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
