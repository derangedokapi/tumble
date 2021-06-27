using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 35f;
    [SerializeField] float padding = 2f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
     

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void Update() {
        Move();
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
     //   var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
      //  var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
      var newYPos = transform.position.y;

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        // viewport is a 0 to 1 range no matter actual size
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
    }
}
