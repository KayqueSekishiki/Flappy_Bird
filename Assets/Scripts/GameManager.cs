using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    public static GameManager Instance { get; private set; }

    [HideInInspector]
    public int score = 0;

    public List<GameObject> obstaclesPrefabs;
    public float obstacleInterval = 1f;
    public float obstacleSpeed = 1f;

    public float obstacleOffsetX;
    public Vector2 obstacleOffsetY = new(0, 0);
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive()
    {
        return !_isGameOver;
    }
    public bool IsGameOver()
    {
        return _isGameOver;
    }

    public void EndGame()
    {
        _isGameOver = true;

        Debug.Log("Game Over... Your scores as " + score);

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please!!!");
    }
}
