using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] Item[] items;

    [SerializeField] int hitpoints;
    [SerializeField] Sprite[] sprites;

    int currentSpriteIndex = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hitpoints -= 1;
        if (hitpoints <= 0)
        {
            Instantiate(items[0], transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];
        currentSpriteIndex++;

    }
}
