using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // ���� ������� ���� ���� ���� �ٽ� �ε��մϴ�.
        //Scene currentScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(currentScene.buildIndex);
        Debug.Log("ggggg");
    }
}
