using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;

    float direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        float xDelta = direction * paddleSpeed * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + xDelta, -6, 6), transform.position.y);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        ballVelocity = new Vector2(ballVelocity.x * direction, ballVelocity.y);
    }
}
