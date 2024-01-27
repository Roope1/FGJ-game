using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _width = 1f;
    [SerializeField] private GameObject[] _obstacles;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (GameManager.Instance.GameActive)
        {
            int obstacleIndex = UnityEngine.Random.Range(0, _obstacles.Count());
            GameObject newObstacle = Instantiate(
                _obstacles[obstacleIndex],
                new Vector3(
                    UnityEngine.Random.Range(
                        (float)(transform.position.x - Math.Floor(_width / 2)),
                        (float)(transform.position.x + Math.Floor(_width / 2))
                        ),
                    transform.position.y,
                    transform.position.z),
                transform.rotation);
            newObstacle.AddComponent<Obstacle>();
            yield return new WaitForSeconds(GameManager.Instance.ObstacleSpawnDelay);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(_width, 1, 1));
    }
}
