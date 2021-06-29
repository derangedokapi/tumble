using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] float speedFactor = 1.3f;
    [SerializeField] float damageFactor = 10f;
    [SerializeField] AudioClip pickupAudioClip;
    AudioControl gameAudio;
    float moveSpeed;
    bool alive;

    GameStatus gameStatus;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    private void Start() {
        alive = true;
        gameStatus = FindObjectOfType<GameStatus>();
        gameAudio = FindObjectOfType<AudioControl>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
            moveSpeed = gameStatus.fallSpeed * speedFactor;
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
        }
        
    }

    public float GetDamageFactor() {
        return damageFactor;
    }

    public float Die() {
        alive = false;
        gameAudio.PlaySound(pickupAudioClip);
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myAnimator.SetBool("isDead",true);
        return damageFactor;
    }
}