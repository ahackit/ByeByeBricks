﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "LIFES: " + FindObjectOfType<Game>().GetLife().ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
