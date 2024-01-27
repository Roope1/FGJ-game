using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CurrentScore = 0;
    public bool GameActive = true;
    public float ObstacleSpeed = 0.4f;
    public float ObstacleSpawnDelay = 2f;
    [SerializeField] private float _obstacleAcceleration = 0.0001f;

    public static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        ObstacleSpeed += _obstacleAcceleration;
        ObstacleSpawnDelay -= _obstacleAcceleration / 2;
    }
}
