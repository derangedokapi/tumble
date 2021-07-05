using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] clouds;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float horizontalVariance = 5f;
    
    float speedFactor = 20f;
    float timeToWait;
    bool spawn = true;
   // GameStatus gameStatus;
    LevelConfigSO levelConfig;


    
    IEnumerator Start()
    {
       // gameStatus = FindObjectOfType<GameStatus>();
        levelConfig = FindObjectOfType<LevelController>().gameLevelObject;
        while (spawn) {
            minSpawnDelay = speedFactor / levelConfig.fallSpeed;
            maxSpawnDelay = (speedFactor * 10) / levelConfig.fallSpeed;
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

    private void Spawn(GameObject myAttacker) {
        var signMult = Random.Range(0,1) < .5? 1 : -1;
        
        var newPos = new Vector3(transform.position.x + Random.Range(-horizontalVariance,horizontalVariance), transform.position.y, transform.position.z);
            GameObject newAttacker = Instantiate(myAttacker, newPos, transform.rotation) 
            as GameObject;
        newAttacker.transform.localScale = new Vector3(1,1,signMult);
        newAttacker.transform.parent = transform; 
    }

    public void StopSpawning() {
        spawn = false;
        // pause the clouds of children?
        if (transform.childCount == 0) return;
        foreach (Transform child in transform) {
            var cloudControl = child.GetComponent<CloudControl>();
            if (cloudControl) {
                child.GetComponent<CloudControl>().StopMoving();
            }
        }
    }

   



}

