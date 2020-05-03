using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;
    float startingSpeed;
    [SerializeField] Sprite[] sprites;
    float direction;
    int currentClass;

    float timePassed;
    float currentTime = 0f;

    bool speedActivated;
    // Start is called before the first frame update
    void Start()
    {

        currentClass = FindObjectOfType<Game>().GetClass();
        GetComponent<SpriteRenderer>().sprite = sprites[currentClass];

        switch (currentClass)
        {
            case 0:
                transform.localScale = new Vector3(1.5f, 1f, 1f);
                paddleSpeed = 8f;
                break;
            case 1:
                paddleSpeed = 15f;
                break;
            default:
                break;

        }

        startingSpeed = paddleSpeed;


    }

    // Update is called once per frame
    void Update()
    {

        if (speedActivated)
        {
            timePassed += Time.deltaTime;
            if (Mathf.Floor(timePassed) > currentTime)
            {
                currentTime = Mathf.Floor(timePassed);
            }
        }
        if (currentTime > 5)
        {
            DeactivateSpeedy();

        }
        direction = Input.GetAxis("Horizontal");
        float xDelta = direction * paddleSpeed * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + xDelta, -6, 6), transform.position.y);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        ballVelocity = new Vector2(ballVelocity.x + direction, ballVelocity.y);
    }

    public void ActivateSpeedy()
    {
        speedActivated = true;
        paddleSpeed *= 1.5f;
    }

    private void DeactivateSpeedy()
    {
        speedActivated = false;
        paddleSpeed = startingSpeed;
        timePassed = 0f;
        currentTime = 0f;
    }
}
