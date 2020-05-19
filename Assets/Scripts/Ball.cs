using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] Arrow arrowPrefab;

    float timePassed;
    float currentTime = 0f;

    bool isFired = false;
    bool fire = false;
    float originalHeight;
    Vector2 myVelocity;
    private Vector2 addedForce = new Vector2(3f, 3f);
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
        if (fire)
        {
            timePassed += Time.deltaTime;
            if (Mathf.Floor(timePassed) > currentTime)
            {
                currentTime = Mathf.Floor(timePassed);
            }
        }
        if (currentTime > 5)
        {
            SetUnfire();

        }

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

        if (fire)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bricks"))
            {
                GetComponent<Rigidbody2D>().velocity = myVelocity + new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(addedForce, ForceMode2D.Force);
        }

        if (myVelocity.y == 0.0f && isFired)
        {
            GetComponent<Rigidbody2D>().velocity = myVelocity + new Vector2(0, 3f);
        }

        if (myVelocity.x == 0.0f && isFired)
        {
            GetComponent<Rigidbody2D>().velocity = myVelocity + new Vector2(3f, 0f);
        }

    }

    public bool IsFired()
    {
        return isFired;
    }
    public void SetFire()
    {
        timePassed = 0f;
        currentTime = 0f;
        fire = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void SetUnfire()
    {
        fire = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public bool IsOnFire()
    {
        return fire;
    }
}
