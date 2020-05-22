using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int jumpToScene;

    #region Singleton
    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            JumpToSpecificLevel();
        }
    }

    private void JumpToSpecificLevel()
    {
        SceneManager.LoadScene(jumpToScene);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
