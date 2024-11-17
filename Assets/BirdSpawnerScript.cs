using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnerScript : MonoBehaviour
{
    public GameObject Bird;
    public float basicSpawnRate = 30;
    private float spawnRate = 30;
    public float spawnRateOffset = 10;
    private float timer = 0;
    public float heightOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
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
            SpawnBird();
            SetSpawnRate();
            timer = 0;
        }
    }

    void SetSpawnRate()
    {
        spawnRate = basicSpawnRate + Random.Range(-(spawnRateOffset), spawnRateOffset);
    }

    void SpawnBird()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Bird, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
    }
}
