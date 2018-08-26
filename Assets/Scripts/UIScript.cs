using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Image tapImage;
    public Image getReadyImage;
    public Text countDownTimer;

    private bool TimerOn = false;
    private bool isBirdDead = false;
    private float timerRun = 0;
    private int timer = 0;
    private int timerTicking = 0;

    public void StartGame()
    {
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
                timerTicking = timer;
                countDownTimer.text = timerTicking.ToString();
            }
        }
    }
	
    public void GameOverUI()
    {
        Debug.Log("GameOverUI");
    }

    public void StopTimer()
    {
        Debug.Log("Timer Stopped!");
        isBirdDead = true;
        TimerOn = false;
    }

}
