using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 35f;
    [SerializeField] float padding = 2f;
    [SerializeField] float tiltAmount = 1.2f;


    GameStatus gameStatus;
    Animator myAnimator;

    InputManager inputManager;

    AudioControl gameAudio;
    Rigidbody2D myRigidBody;

    float xMin;
    float xMax;

    Vector3 origPos;

    bool moving = true;



     

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        SetUpMoveBoundaries();
        gameStatus = FindObjectOfType<GameStatus>();
        myAnimator = GetComponent<Animator>();
        gameAudio = FindObjectOfType<AudioControl>();
        myRigidBody = GetComponent<Rigidbody2D>();
        inputManager = FindObjectOfType<InputManager>();

    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (!moving) return;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = transform.position.y;
        transform.position = new Vector2(newXPos, newYPos);
        
        float xPos = gameObject.transform.position.x * tiltAmount;
        transform.rotation = Quaternion.Euler (0, 0, xPos);
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        // viewport is a 0 to 1 range no matter actual size
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Coin":
                other.gameObject.GetComponent<CoinControl>().PickupCoin();
                break;
            case "Enemy":
                EnemyControl enemy = other.gameObject.GetComponent<EnemyControl>();
                float damage = enemy.Die();
                gameStatus.PlayerTakeDamage(damage);
                myAnimator.SetTrigger("Damage");
                
                //Destroy(other.gameObject);
                break;
            case "Ground":
                
                moving = false;
                myRigidBody.bodyType = RigidbodyType2D.Static;
                var moreLevels = (gameStatus.currentLevel + 1) < gameStatus.levelConfigOptions.Length;
                Debug.Log("testing if "+(gameStatus.currentLevel+1)+" < "+gameStatus.levelConfigOptions.Length+" ?"+moreLevels);
                if (moreLevels) {
                    inputManager.LoadLevelPanel();
                } else {
                    inputManager.LoadGameOverPanel();
                }
                
                break;
            
        }
    
    }

    public void DamageOver() {
        //myAnimator.ResetTrigger("Damage");
        myAnimator.SetBool("isIdle", true);
    }

    public void FallToGround() {
        Debug.Log("falling to ground");
        moving = false;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
    }



   


}
