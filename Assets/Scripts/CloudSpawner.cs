using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    
    
    float speedFactor = 20f;
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

    private void Spawn(GameObject myAttacker) {
        var signMult = Random.Range(0,1) < .5? 1 : -1;
        var newPos = new Vector3(transform.position.x + Random.Range(-1,1), transform.position.y + Random.Range(-1,1), transform.position.z);
            GameObject newAttacker = Instantiate(myAttacker, newPos, transform.rotation) 
            as GameObject;
        newAttacker.transform.localScale = new Vector3(1,1,signMult);
        newAttacker.transform.parent = transform; 
    }

   



}

