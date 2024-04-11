using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float _coolDown = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        if (gameManager.IsGameOver()) return;

        _coolDown -= Time.deltaTime;

        if (_coolDown <= 0f)
        {
            _coolDown = GameManager.Instance.obstacleInterval;

            int prefabIndex = Random.Range(0, gameManager.obstaclesPrefabs.Count);
            GameObject prefab = gameManager.obstaclesPrefabs[prefabIndex];

            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);

            Vector3 position = new Vector3(x, y, 0);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
