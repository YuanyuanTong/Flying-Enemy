using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform prefabToSpawn;
    public int enemyCount = 3;
    public float spawnRadius = 5;
    private GameObject playerObj = null;
    public float spawnCollisionCheckRadius = 1; // This is related to the size of spawn prefab
    public float spawnTriggerDistance = 10;
    private bool spawned = false;
    int layerMask = 1 << 3;
    void Awake() {
        // find player by tag
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned && Vector3.Distance(transform.position, playerObj.transform.position) < spawnTriggerDistance)
        {
            int i = 0;
            while (i < enemyCount)
            {
                Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
                spawnPos.y = 1.5f;

                // ignore layer 3 when considering collision
                // i.e. colliding with layer 3 is not counted as collision
                if (!Physics.CheckSphere(spawnPos, spawnCollisionCheckRadius, ~layerMask))
                {
                    // Instantiate(prefabToSpawn, spawnPos, Random.rotation);
                    Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
                    ++i;
                }
            }
            spawned = true;
        }
    }
}
