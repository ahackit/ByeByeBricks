using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string type;
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
            if (type == "fire")
            {
                FindObjectOfType<Game>().FireActivated();
            }
            if (type == "speed")
            {
                FindObjectOfType<Game>().SpeedActivated();
            }
        }


        Destroy(gameObject);
    }
}
