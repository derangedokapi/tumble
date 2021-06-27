using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 35f;
    [SerializeField] float padding = 2f;
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
        
        float xPos = gameObject.transform.position.x * 3;
        transform.rotation = Quaternion.Euler (0, 0, xPos);
        
/*
        Vector3 moveDirection = gameObject.transform.position - origPos;    
        if (moveDirection != Vector3.zero) 
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       }
       */
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        // viewport is a 0 to 1 range no matter actual size
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }
}
