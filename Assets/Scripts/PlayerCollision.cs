using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverUI;

    private bool isGameOver = false;

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isGameOver)
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            if (gameOverUI != null)
                gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
