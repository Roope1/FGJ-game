using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _speed = 0.055f;

    private float _offset = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _offset += GameManager.Instance.ObstacleSpeed * _speed;
        _renderer.material.SetTextureOffset("_BaseMap", new Vector2(0, _offset));
    }
}
