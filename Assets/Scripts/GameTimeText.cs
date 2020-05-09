using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeText : MonoBehaviour
{
    // Start is called before the first frame update

    float timePassed;
    float currentTime = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (Mathf.Floor(timePassed) > currentTime)
        {
            currentTime = Mathf.Floor(timePassed);
            GetComponent<Text>().text = "TIME: " + currentTime.ToString();
        }


    }
}
