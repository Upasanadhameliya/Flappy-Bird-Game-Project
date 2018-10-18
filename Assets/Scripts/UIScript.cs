using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

    [Header("Gameplay UI")]
    #region Gameplay UI
    public Image tapImage = null;
    public Image getReadyImage = null;
    public Text countDownTimer = null;
    #endregion

    [Header("Gameover UI")]
    #region Game Over UI 
    public Image gameOverImage;
    public Image scoreBoard;
    public Image bronzeMedal;
    public Image silverMedal;
    public Image goldMedal;
    public Image platinumMedal;
    [Space(20)]
    public Text bronzeMedalText;
    public Text silverMedalText;
    public Text goldMedalText;
    public Text platinumMedalText;
    public Text scoreText;
    public Text bestScoreText;
    [Space(20)]
    public Image retryButtonImage;
    public Button retryButton;

    #endregion

    private bool TimerOn = false;
    private bool isBirdDead = false;
    private float timerRun = 0;
    private int timer = 0;
    private int timerTicking = 0;
    private GameControl gameController;
    AudioSource timerAudio;
    //private bool isGameOver = false;

    /*private void Start()
    {
        Debug.Log("Start method call");
        
    }*/

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnStartOfNewGame;
    }

    void OnStartOfNewGame(Scene scene, LoadSceneMode load)
    {

        #region Gameplay UI

        tapImage = GameObject.FindGameObjectWithTag("TapImage").GetComponent<Image>();
        getReadyImage = GameObject.FindGameObjectWithTag("GetReadyImage").GetComponent<Image>();
        countDownTimer = GameObject.FindGameObjectWithTag("CountDownTimer").GetComponent<Text>();

        #endregion

        #region Game Over UI

        gameOverImage = GameObject.FindGameObjectWithTag("GameOverImage").GetComponent<Image>();
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Image>();
        bronzeMedal = GameObject.FindGameObjectWithTag("Bronze").GetComponent<Image>(); ;
        silverMedal = GameObject.FindGameObjectWithTag("Silver").GetComponent<Image>(); ;
        goldMedal = GameObject.FindGameObjectWithTag("Gold").GetComponent<Image>(); ;
        platinumMedal = GameObject.FindGameObjectWithTag("Platinum").GetComponent<Image>();

        bronzeMedalText = GameObject.FindGameObjectWithTag("BronzeText").GetComponent<Text>(); ;
        silverMedalText = GameObject.FindGameObjectWithTag("SilverText").GetComponent<Text>(); ;
        goldMedalText = GameObject.FindGameObjectWithTag("GoldText").GetComponent<Text>(); ;
        platinumMedalText = GameObject.FindGameObjectWithTag("PlatinumText").GetComponent<Text>();

        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        bestScoreText = GameObject.FindGameObjectWithTag("BestScoreText").GetComponent<Text>();

        retryButtonImage = GameObject.FindGameObjectWithTag("RetryButton").GetComponent<Image>();

        retryButton = GameObject.FindGameObjectWithTag("RetryButton").GetComponent<Button>();
        retryButton.onClick.AddListener(OnClickRetry);

        #endregion

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        timerAudio = countDownTimer.GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnStartOfNewGame;
    }

    public void StartGame()
    {
        //Debug.Log("StartGame call");
        tapImage.enabled = false;
        getReadyImage.enabled = false;
        StartCoroutine("StartCountDownTimer");
    }

    private IEnumerator StartCountDownTimer()
    {
        yield return new WaitForSeconds(2f);
        if (!isBirdDead)
        {
            TimerOn = true;
            countDownTimer.enabled = true;
        }
    }

    private void Update()
    {
        if(TimerOn)
        {
            timerRun += Time.deltaTime;
            timer = (int)timerRun;
            if (timer > timerTicking)
            {
                timerAudio.Play();
                timerTicking = timer;
                countDownTimer.text = timerTicking.ToString();
            }
        }
    }

    public void GameOverUI()
    {
        //Debug.Log("GameOverUI");

        #region Enable UI
        countDownTimer.enabled = false;
        gameOverImage.enabled = true;
        scoreBoard.enabled = true;
        scoreText.enabled = true;
        bestScoreText.enabled = true;
        retryButtonImage.enabled = true;
        retryButton.enabled = true;
        #endregion
        scoreText.text = timerTicking.ToString();

        if (timerTicking >= 10 && timerTicking < 20) { bronzeMedal.enabled = true; bronzeMedalText.enabled = true; }
        else if (timerTicking >= 20 && timerTicking < 30) { silverMedal.enabled = true; silverMedalText.enabled = true; }
        else if (timerTicking >= 30 && timerTicking < 40) { goldMedal.enabled = true; goldMedalText.enabled = true; }
        else if (timerTicking >= 40) { platinumMedal.enabled = true; platinumMedalText.enabled = true; }

        if(PlayerPrefs.GetInt("HighScore") < timerTicking)
        {
            PlayerPrefs.SetInt("HighScore", timerTicking);
        }

        bestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void StopTimer()
    {
        //Debug.Log("Timer Stopped!");
        isBirdDead = true;
        TimerOn = false;
    }

    void OnClickRetry()
    {
        gameController.ChangeScene();
    }
}
