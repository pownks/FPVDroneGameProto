using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)   Instance = this;
    }

    #endregion

    public float currentScore = 0f;

    public bool isPlaying = true;

    public float multiplier = 10f;

    [SerializeField] private GameObject gameOverScreen;

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime * multiplier;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isPlaying = false;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
