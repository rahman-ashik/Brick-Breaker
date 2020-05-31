using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed=70;
    private float rightBound=2.53f;
    private float leftBound=-2.53f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); //movement

        if (transform.position.x < leftBound) transform.position = new Vector2(leftBound, transform.position.y);
        if (transform.position.x > rightBound) transform.position = new Vector2(rightBound, transform.position.y);
    }
}
