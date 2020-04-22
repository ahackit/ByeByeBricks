using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xDelta = Input.GetAxis("Horizontal") * paddleSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + xDelta, transform.position.y);

    }
}
