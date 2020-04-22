using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField] Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateText();

    }
}
