using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; 

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Transform spawnPoint; 
    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;

    public PathManager pathManager;

    void Start ()
    {
        StartCoroutine(WaitForMapCreation());
    }
    
    IEnumerator WaitForMapCreation()
    {
        while (!pathManager.mapCreated)
        {
            yield return null;
        }

        Debug.Log("Map created. Start wave spawner");
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (countdown <= 0f)
            {
                Debug.Log("Wave Coming");
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves; 
            }

            yield return null;
            countdown -= Time.deltaTime * WorldTime.getActionSpeed();
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            waveCountdownText.text = string.Format("Next Wave : {0:00.0}", countdown);
        }
    }

    /*void Update ()
    {
        countdown -= Time.deltaTime * WorldTime.getActionSpeed();

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("Next Wave : {0:00.0}", countdown);
    }*/

    public void SkipWave()
    {
        countdown = 0f;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.waves++;
        for (int i = 0; i < waveIndex; i++)
        {
            Debug.Log("Spawn");
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f / WorldTime.getActionSpeed());
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, pathManager.startTilePosition, spawnPoint.rotation);
        Debug.Log("start is : " + pathManager.startTilePosition);
    }

}
