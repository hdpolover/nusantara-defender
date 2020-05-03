using Polover.NusantaraDefender.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject[] ghostPrefabs;

    public FloatReference spawnInterval;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator Spawn()
    {
        SpawnGhost(RandomGhostToSpawn());

        yield return new WaitForSeconds(spawnInterval);

        waveIndex++;
    }

    void SpawnGhost(int index)
    {
        Instantiate(ghostPrefabs[index], transform.position, Quaternion.identity);
    }

    private int RandomGhostToSpawn()
    {
        return Random.Range(0, ghostPrefabs.Length);
    }
}
