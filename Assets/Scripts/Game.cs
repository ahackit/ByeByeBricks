using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text lifeText;

    [SerializeField] int selectedClass;
    public int lives = 3;
    int score = 0;

    int maxFiredBalls = 1;
    int currentFiredBalls;

    float dropRate = .5f;
    // Start is called before the first frame update

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Game>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void UpdateText()
    {

        FindObjectOfType<ScoreText>().GetComponent<Text>().text = score.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateText();

    }

    private void UpdateLifeText()
    {

        FindObjectOfType<LifeText>().GetComponent<Text>().text = lives.ToString();
    }

    public void LoseLife()
    {
        lives -= 1;
        if (lives < 0)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }
        UpdateLifeText();

    }

    public void SetClass(int classNumber)
    {
        selectedClass = classNumber;

        if (classNumber == 1)
        {
            maxFiredBalls = 2;
        }
        else if (classNumber == 2)
        {
            dropRate = 1f;
        }
    }
    public int GetClass()
    {
        return selectedClass;
    }

    public void IncrementFiredBalls()
    {
        currentFiredBalls += 1;
    }
    public void DecrementFiredBalls()
    {
        currentFiredBalls -= 1;
    }
    public bool CanFire()
    {
        if (currentFiredBalls == maxFiredBalls)
        {
            return false;
        }
        return true;

    }

    public float GetDropRate()
    {
        return dropRate;
    }
}
