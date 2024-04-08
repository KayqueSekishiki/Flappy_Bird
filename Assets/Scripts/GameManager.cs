using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
}
