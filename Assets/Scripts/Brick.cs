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

    void OnCollisionEnter2D(Collision2D collision)
    {
        hitpoints -= 1;
        if (hitpoints <= 0)
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
            Instantiate(particleSystems[currentSpriteIndex], transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            Destroy(gameObject);
            return;
        }
        Instantiate(particleSystems[currentSpriteIndex], transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
        GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];
        currentSpriteIndex++;

    }
}
