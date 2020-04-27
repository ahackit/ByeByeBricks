using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 previousPosition = new Vector3(0f, 0f, 0f);
    float currentDistance;

    float currentRotation = 120f;
    Ball target;
    void Start()
    {

        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            if (!ball.IsFired())
            {
                target = ball;
            }
        }
        currentDistance = target.transform.position.x - transform.position.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        float newX = target.transform.position.x - currentDistance;
        float currentZ = transform.rotation.eulerAngles.z;
        transform.position = new Vector2(newX, transform.position.y);
        if (currentZ >= 90f && currentZ <= 180f)
        {
            currentRotation = -120f;
        }
        if (currentZ <= 270f && currentZ >= 180f)
        {
            currentRotation = 120f;
        }
        transform.RotateAround(target.transform.position, transform.forward, currentRotation * Time.deltaTime);
        currentDistance = target.transform.position.x - transform.position.x;

    }


    public Vector2 GetDirection()
    {
        return transform.position;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
