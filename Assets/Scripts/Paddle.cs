using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;
    float startingSpeed;
    Vector3 startingScale;
    [SerializeField] Sprite[] sprites;
    float direction;
    int currentClass;

    bool speedActivated;
    float timePassed;
    float currentTime = 0f;
    bool sizeyActive;
    float timePassedSizey;
    float currentTimeSizey = 0f;


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
        startingScale = transform.localScale;


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


        if (sizeyActive)
        {
            timePassedSizey += Time.deltaTime;
            if (Mathf.Floor(timePassedSizey) > currentTimeSizey)
            {
                currentTimeSizey = Mathf.Floor(timePassedSizey);
            }
        }
        if (currentTimeSizey > 5)
        {
            DeactivateSizey();

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

    public void ActivateSizey()
    {
        sizeyActive = true;
        transform.localScale = startingScale;
        transform.localScale = new Vector3(transform.localScale.x * 1.5f, 1f, 1f);
    }
    public void DeactivateSizey()
    {
        transform.localScale = startingScale;
        sizeyActive = false;
        timePassedSizey = 0f;
        currentTimeSizey = 0f;

    }

}
