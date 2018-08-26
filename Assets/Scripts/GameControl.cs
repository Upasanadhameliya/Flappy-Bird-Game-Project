using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private bool created = false;
    private bool playerCanStart = false;
    private bool isGameOver = false;
    private bool sceneChanged = false;
    public UIScript gameUI;
    public GameObject obj;

	void Start () {

	    if(!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
	}

    private void Update()
    {
        if(sceneChanged)
        {
            obj = GameObject.FindGameObjectWithTag("Canvas");
            if(obj != null) gameUI = obj.GetComponent<UIScript>() as UIScript;
            if (gameUI != null)
            {
                sceneChanged = false;
            }
        }

        if(Input.GetMouseButton(0) && playerCanStart)
        {
            Time.timeScale = 1;
            gameUI.StartGame();
            playerCanStart = !playerCanStart;
        }

        if(isGameOver)
        {
            //Time.timeScale = 0;
            isGameOver = !isGameOver;
            gameUI.GameOverUI();
            Debug.Log("Game Over");
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene2");        
        Time.timeScale = 0;
        sceneChanged = true;
        playerCanStart = true;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
