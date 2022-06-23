using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GravityAttractor attractor;

    private float spawnRangeX = 50;
    private float spawnRangeY = 50;
    private float spawnRangeZ = 50;
    private float startDelay = 2;
    private float spawnInterval = 1f;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        InvokeRepeating("SpawnFireball", startDelay, spawnInterval);
    }

    // Update is called once per frame


    float RandomFloatFromRange(float range)
    {
        return Random.Range(-range, range);
    }


    void SpawnFireball()
    {
        Vector3 spawnPos = new Vector3(
            RandomFloatFromRange(spawnRangeX),
            RandomFloatFromRange(spawnRangeY),
            RandomFloatFromRange(spawnRangeZ)
            );

        GameObject fireball = Instantiate(
            fireballPrefab, spawnPos,
            fireballPrefab.transform.rotation
        );
        count += 1;
        fireball.GetComponent<GravityBody>().attractor = attractor;
    }
}
