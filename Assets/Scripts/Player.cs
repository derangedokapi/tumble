using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 35f;
    [SerializeField] float padding = 2f;
    [SerializeField] float tiltAmount = 1.2f;
    [SerializeField] AudioClip moneySound;
    float xMin;
    float xMax;

    Vector3 origPos;


     

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        SetUpMoveBoundaries();
    }

    private void Update() {
        Move();
    }

    private void Move() {
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
        
        if (other.tag == "Coin") {
            Debug.Log("hit by "+other);
            AudioSource.PlayClipAtPoint(moneySound, Camera.main.transform.position);
            Destroy(other.gameObject);
        }
    
    }
}
