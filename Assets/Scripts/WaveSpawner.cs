using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; 
    
    public Transform spawnPoint; 
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;

    void Update ()
    {
        if(countdown <= 0f) 
        {
            Debug.Log("Vague en route !");
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves ;
        }

        countdown -= Time.deltaTime * WorldTime.getActionSpeed();

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("Next Wave : {0:00.0}", countdown);
    }

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
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f / WorldTime.getActionSpeed());
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}