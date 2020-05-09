using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string type;
    [SerializeField] AudioClip clip;
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

        if (collider.gameObject.layer == LayerMask.NameToLayer("Paddle"))
        {


            if (type == "coin")
            {
                FindObjectOfType<Game>().UpdateScore(100);
            }
            else if (type == "fire")
            {
                FindObjectOfType<Game>().FireActivated();
            }
            else if (type == "speed")
            {
                FindObjectOfType<Game>().SpeedActivated();
            }
            else if (type == "oneup")
            {
                FindObjectOfType<Game>().AddLife();
            }
            else if (type == "sizeup")
            {
                FindObjectOfType<Game>().AddSize();
            }
            else if (type == "bomb")
            {
                FindObjectOfType<Game>().LoseLife();
            }
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        Destroy(gameObject);
    }
}
