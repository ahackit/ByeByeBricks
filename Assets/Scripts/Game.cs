using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text lifeText;
    public int lives = 3;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        UpdateLifeText();

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

    private void UpdateLifeText()
    {
        lifeText.text = lives.ToString();
    }

    public void LoseLife()
    {
        lives -= 1;
        UpdateLifeText();
    }
}
