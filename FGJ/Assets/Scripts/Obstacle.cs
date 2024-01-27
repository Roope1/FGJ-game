using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _speed;
    private bool _scoreUpdated = false;

    void Start()
    {
        gameObject.tag = "Obstacle";
    }

    private void FixedUpdate()
    {
        _speed = GameManager.Instance.ObstacleSpeed;
        transform.position += transform.rotation * new Vector3(0, 0, _speed);
        if (transform.position.z > 9 && !_scoreUpdated)
        {
            GameManager.Instance.CurrentScore += 1;
            _scoreUpdated = true;
        }
        if (transform.position.z > 35f)
        {
            Destroy(gameObject);
        }
    }
}
