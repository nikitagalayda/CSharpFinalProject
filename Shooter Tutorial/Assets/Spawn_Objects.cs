using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Objects : MonoBehaviour {

    public Transform AsteroidSpawner;
    public GameObject asteroid;
    public float spawnTime;

    private float spawnCooldown;
    private float spawnOffset;
	void Start () {
        spawnCooldown = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            spawnOffset = Random.Range(-5, 5);

            Instantiate(asteroid, AsteroidSpawner.position + new Vector3(spawnOffset, 0.0f, 0.0f), AsteroidSpawner.rotation);
            spawnCooldown = spawnTime;
        }
    }
}
