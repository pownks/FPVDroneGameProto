using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerScript : MonoBehaviour
{
    public GameObject Ground;
    public float spawnRate = 30;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGround();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            SpawnGround();
            timer = 0;
        }
    }

    private void SpawnGround()
    {
        Instantiate(Ground, new Vector3(transform.position.x, transform.position.y), transform.rotation);
    }
}
