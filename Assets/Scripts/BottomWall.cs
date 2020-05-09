using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Destroy(collider.gameObject);
            return;
        }
        Game game = FindObjectOfType<Game>();
        game.LoseLife();
        game.DecrementFiredBalls();
        if (game.lives < 0)
        {
            Destroy(collider.gameObject);
            return;
        }
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            if (!ball.IsFired())
            {
                Destroy(collider.gameObject);
                return;

            }
        }
        collider.gameObject.GetComponent<Ball>().Reset();


    }
}
