using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private bool created = false;
    private bool playerCanStart = false;
    private bool isGameOver = false;
    public bool sceneChanged = false;
    public UIScript gameUI;
    public GameObject canvas;
    public AudioScript gameAudio;

	void Start () {

	    if(!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        PlayerPrefs.SetInt("HighScore", 0);
    }

    private void Update()
    {
        if(sceneChanged)
        {
            if (canvas == null)
            {
                canvas = GameObject.FindGameObjectWithTag("Canvas");
                if (canvas != null) gameUI = canvas.GetComponent<UIScript>() as UIScript;
                if (gameUI != null)
                {
                    //Debug.Log("Game UI got");
                    sceneChanged = false;
                }
                gameAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioScript>();
            }
        }

        if(Input.GetMouseButton(0) && playerCanStart)
        {
            Time.timeScale = 1;
            gameUI.StartGame();
            playerCanStart = !playerCanStart;
            gameAudio.StartGame();
        }

        if(isGameOver)
        {
            //Time.timeScale = 0;
            isGameOver = !isGameOver;
            gameUI.GameOverUI();
            //Debug.Log("Game Over");
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene2",LoadSceneMode.Single);        
        Time.timeScale = 0;
        sceneChanged = true;
        //Debug.Log("Scene Change: "+ sceneChanged);
        playerCanStart = true;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void BirdHit()
    {
        gameAudio.BirdHit();
    }
}
