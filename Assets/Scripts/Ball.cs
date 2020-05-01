using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] Arrow arrowPrefab;


    bool isFired = false;
    float originalHeight;
    Vector2 myVelocity;
    // Start is called before the first frame update
    void Start()
    {
        originalHeight = transform.position.y;

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + .7f, 0);
        Instantiate(arrowPrefab, newPosition, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        myVelocity = GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKeyDown("space") && !isFired)
        {
            isFired = true;
            Arrow arrow = FindObjectOfType<Arrow>();
            transform.rotation = arrow.transform.rotation;
            GetComponent<Rigidbody2D>().velocity = transform.up * 6f;
            arrow.DestroySelf();
            Game game = FindObjectOfType<Game>();
            game.IncrementFiredBalls();
            if (game.GetClass() == 1 && game.CanFire())
            {
                Instantiate(this, new Vector2(paddle.transform.position.x, originalHeight), Quaternion.identity);
            }
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

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + .7f, 0);
        Instantiate(arrowPrefab, newPosition, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFired)
        {



            GetComponent<Rigidbody2D>().velocity = myVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public bool IsFired()
    {
        return isFired;
    }
    public void SetFire()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
}
