using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    [Header("Attributes")]
    public GameObject[] enemyPrefab;
    public Transform spawnPoint;

    [Header("WaveSettings")]
    public float waveDelay = 10f;
    private float countdown = 10f;
    public int [] waveSizes;

    public Text waveCountdownText;
    private float currWaveSpeed = .2f;
    private int currWave = 0;

    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            CountdownReset();
        } else
        {
            CountdownTick();
        }
    }

    /* Game */
    IEnumerator SpawnWave()
    {
        currWave++;
        for (int i = 0; i < CalculateWaveSize(); i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(CalculateSpawnDelay());
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(GetCurrentEnemy(), spawnPoint.position, spawnPoint.rotation) as GameObject;
    }
    
    GameObject GetCurrentEnemy()
    {
        return currWave % 2 > 0 ? enemyPrefab[0] : enemyPrefab[1];
    }

    int CalculateWaveSize()
    {
        return waveSizes[currWave % waveSizes.Length];
    }

    float CalculateSpawnDelay()
    {
        return currWave % 2 > 0 ? .35f : .1f;
    }

    /* Timer */
    void CountdownReset()
    {
        countdown = waveDelay;
    }

    void CountdownTick()
    {
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00},", countdown);
            //Mathf.Floor(countdown + 1f).ToString();
    }

    
}
