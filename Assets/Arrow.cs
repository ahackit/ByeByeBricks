using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 previousPosition = new Vector3(0f, 0f, 0f);
    float currentDistance;
    Ball target;
    void Start()
    {

        target = FindObjectOfType<Ball>();
        currentDistance = target.transform.position.x - transform.position.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = new Vector2(target.transform.position.x * Vector2.Distance(target.transform.position, transform.position), transform.position.y);
        // transform.RotateAround(target.transform.position, Vector3.forward, 30f * Time.deltaTime);
        // Debug.Log("Ball");
        // Debug.Log(target.transform.position);
        // Debug.Log("Arrow");
        // Debug.Log(transform.position);
        // Debug.Log("Distance");
        // Debug.Log(Vector2.Distance(transform.position, target.transform.position));
        Debug.Log(currentDistance);

        float newX = target.transform.position.x - currentDistance;
        Debug.Log(newX);
        transform.position = new Vector2(newX, transform.position.y);
        transform.RotateAround(target.transform.position, transform.forward, 120f * Time.deltaTime);
        currentDistance = target.transform.position.x - transform.position.x;

    }
}
