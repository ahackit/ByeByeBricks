using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;

    bool isFired = false;
    float originalHeight;
    // Start is called before the first frame update
    void Start()
    {
        originalHeight = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            isFired = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 8f);
        }
        if (!isFired)
        {
            transform.position = new Vector2(paddle.transform.position.x, transform.position.y);
            return;
        }

    }

    public void Reset()
    {
        transform.position = new Vector2(paddle.transform.position.x, originalHeight);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        isFired = false;
    }
}
