using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private float startZ;
    private int score;

    void Start()
    {
        startZ = player.position.z;
    }

    void Update()
    {
        float distance = player.position.z - startZ;
        score = Mathf.FloorToInt(distance);
        scoreText.text = "Score: " + score.ToString();
    }
}

