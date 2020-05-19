using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Text>().text = "Final Score:" + FindObjectOfType<Game>().GetScore().ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
