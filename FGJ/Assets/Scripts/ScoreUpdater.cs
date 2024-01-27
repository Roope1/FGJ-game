using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = gameObject.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.Instance.GameActive) return;
        _text.SetText("Score: {}", GameManager.Instance.CurrentScore);
    }
}
