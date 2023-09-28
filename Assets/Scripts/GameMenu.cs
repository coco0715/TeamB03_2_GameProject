using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    bool currentPlay = false;
    bool gameQuitBtn = false;
    bool gameSaveCheck = false;
    bool gameQuitAgree = false;

    // TODO
    // �ش� ���� �� �����ϱ�
    public void PlayGame()
    {
        // Play ���� ������ ���� ��� StartScene �̵�
        if (currentPlay == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Play ���� �������� �̵�
        else
        {
            
        }
    }

    // TODO
    // ���� ���� Ȯ�� �˾�
    // ���� Play���� ������ ���� ��� ���� Ȯ�� �˾�
    public void QuitGame()
    {
        if (gameQuitBtn == true)
        {
            if (gameSaveCheck && gameQuitAgree)
            {
                Application.Quit();
            }
        }
        else
        {
            Debug.Log("Quit");
        }
        
    }
}
