using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [HideInInspector]
    public static int enemiesAlive;

    public Text waveText, remainingEnemies;

    public WaveManager[] waves;
    
    public Transform spawnLocation;    
    
    public float timeBetweennWaves, countdownNextWave;

    int waveIndex, waveMonstersAmount;
	
	void Update () {
        remainingEnemies.text = "Remaining: " + enemiesAlive + " of " +  waveMonstersAmount;      
        // Will not spawn more enemies, while there are enemies alive
        //if(enemiesAlive > 0){
        //    return;
        //}
                
        if(countdownNextWave <= 0){
            StartCoroutine(SpawnWave());
            countdownNextWave = timeBetweennWaves;
            return;
        }

        countdownNextWave -= Time.deltaTime;
	}
    
    IEnumerator SpawnWave(){
        WaveManager wave = waves[waveIndex];  
		
        if(waveIndex == waves.Length - 1){
            waveText.text = "Last Wave";
        } else {
			waveText.text = "Wave: " + waveIndex + " of " + waves.Length;
        }

        
        
      // Increment the wave number
        for (int i = 0; i < wave.amountofEnemies; i++) {
            waveMonstersAmount = wave.amountofEnemies;
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        waveIndex++;
        
        if(waveIndex == waves.Length){
            print("Level Finished");
            //Make this script disable, so stops spawning
            enabled = false;            
        }
    }
    
    void SpawnEnemy(GameObject enemy){
        Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);
        enemiesAlive++;        
    }
}
