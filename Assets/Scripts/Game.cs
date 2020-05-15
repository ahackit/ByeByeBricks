using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField] Text scoreText;

    [SerializeField] Texture2D cursorTexture;
    [SerializeField] Text lifeText;

    [SerializeField] int selectedClass;
    public int lives = 3;
    public int bricks = 0;
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
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void UpdateText()
    {

        FindObjectOfType<ScoreText>().GetComponent<Text>().text = "SCORE: " + score.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateText();

    }

    private void UpdateLifeText()
    {

        FindObjectOfType<LifeText>().GetComponent<Text>().text = "LIFES: " + lives.ToString();
    }
    public void LoadFirstLevel()
    {

        FindObjectOfType<LevelLoader>().LoadNextLevel();
        lives = 3;
        bricks = 0;
        currentFiredBalls = 0;
        score = 0;
    }
    public void BrickSpawned()
    {
        bricks++;
    }
    public void BrickBroken()
    {
        bricks--;
        UpdateScore(10);
        if (bricks == 0)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
            currentFiredBalls = 0;
            bricks = 0;

        }

    }


    public void LoseLife()
    {
        lives -= 1;
        if (lives < 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();
            lives = 3;
            score = 0;
        }
        UpdateLifeText();
    }

    public int GetLife()
    {
        return lives;
    }

    public int GetScore()
    {
        return score;
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

    public void FireActivated()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.SetFire();
        }
    }

    public void SpeedActivated()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.ActivateSpeedy();
    }

    public void AddLife()
    {
        lives += 1;
        UpdateLifeText();
    }

    public void AddSize()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        paddle.ActivateSizey();
    }
}
