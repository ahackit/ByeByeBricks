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
    void Start()
    {
        // UpdateText();
        // UpdateLifeText();

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
        if (lives < 0)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }
        UpdateLifeText();

    }

    public void SetClass(int classNumber)
    {
        selectedClass = classNumber;
    }
    public int GetClass()
    {
        return selectedClass;
    }
}
