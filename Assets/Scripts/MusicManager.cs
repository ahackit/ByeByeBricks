using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{


    void Awake()
    {
        int musicManagerStatusCOunt = FindObjectsOfType<MusicManager>().Length;
        if (musicManagerStatusCOunt > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
