using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] Item[] items;
    [SerializeField] Item bomb;

    [SerializeField] int hitpoints;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] particleSystems;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip deathClip;

    int currentSpriteIndex = 0;

    void Start()
    {
        FindObjectOfType<Game>().BrickSpawned();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Random.Range(0f, 1f) <= FindObjectOfType<Game>().GetDropRate())
        {
            if (Random.Range(0f, 1f) > .75f && FindObjectOfType<Game>().GetClass() == 2)
            {
                Instantiate(bomb, transform.position, Quaternion.identity);
            }
            else
            {
                int index = Random.Range(0, items.Length);
                Instantiate(items[index], transform.position, Quaternion.identity);
            }

        }
        hitpoints -= 1;
        if (hitpoints <= 0)
        {
            Instantiate(particleSystems[currentSpriteIndex], transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            FindObjectOfType<Game>().BrickBroken();
            Destroy(gameObject);
            return;
        }

        Instantiate(particleSystems[currentSpriteIndex], transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
        GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];
        currentSpriteIndex++;

    }
}
