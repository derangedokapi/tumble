using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] CloudControl[] clouds;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    float speedFactor = 10f;
    float timeToWait;
    bool spawn = true;
    GameStatus gameStatus;
    
    IEnumerator Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        
        while (spawn) {
            minSpawnDelay = speedFactor / gameStatus.fallSpeed;
            maxSpawnDelay = (speedFactor * 10) / gameStatus.fallSpeed;
            timeToWait = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(timeToWait);
            SpawnAttacker();
        }
    }

    public void TurnOffSpawn() {
        spawn = false;
    }

    // Update is called once per frame
    private void SpawnAttacker()
    {
        if (!spawn) {return;}
        if (clouds.Length > 0) {
            var attackerIndex = Random.Range(0, clouds.Length);
            Spawn(clouds[attackerIndex]);
        } else {
            Debug.LogWarning("No prefab clouds assigned for "+gameObject.name);
        }
        
    }

    private void Spawn(CloudControl myAttacker) {
            CloudControl newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) 
            as CloudControl;
        newAttacker.transform.parent = transform; 
    }
}

