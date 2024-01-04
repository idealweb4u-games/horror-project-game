//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System;
//using UnityEngine.Events;

//public class Timer : Singleton<Timer> {
//    public Text timeText;
//    public Text highestTimeRecord;
//    public Text currentTime;
//    public static float
//        time,
//        HighestTime
//        ;
//    public UnityEvent OnTimeComplete = new UnityEvent();

//    private float mTimeDuration;
//    private bool timerIsRunning = false;
//    private int startCount;

//    private void Start() {
//        PlayerPrefs.GetInt("startCount");
//    }
//    void Update() {
//        TimeDuration(mTimeDuration, timerIsRunning);
//        TimeStartFromZero();
//    }

//    public void TimeDuration(float timeDuration, bool isTimerStarted) {
//        timerIsRunning = isTimerStarted;
//        mTimeDuration = timeDuration;
//        if (timerIsRunning) {
//            timerIsRunning = true;
//            if (mTimeDuration > 0) {
//                mTimeDuration -= Time.deltaTime;
//                displayTime(mTimeDuration);
//            } else {
//                mTimeDuration = 0;
//                timerIsRunning = false;
//                OnTimeComplete?.Invoke();
//            }
//        }
//    }
//    public void TimeStartFromZero() {
//        mTimeDuration += Time.deltaTime;
//        displayTime(mTimeDuration);
//        LevelCompletePoint.Instance.onCompleteLevel.AddListener(() => {
//            if (PlayerPrefs.GetInt("startCount") == 0) {
//                PlayerPrefs.SetFloat("HighestTimeDuration", mTimeDuration);
//                PlayerPrefs.SetInt("startCount", 1);
//            } else if (mTimeDuration < PlayerPrefs.GetFloat("HighestTimeDuration")) {
//                PlayerPrefs.SetFloat("HighestTimeDuration", mTimeDuration);
//            }
//            Time.timeScale = 0;
//            currentTime.text = displayTime(mTimeDuration);
//            highestTimeRecord.text = displayTime((PlayerPrefs.GetFloat("HighestTimeDuration")));
//        });
//    }
//    string displayTime(float timeToDisplay) {
//        timeToDisplay += 1;
//        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
//        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
//        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//        return timeText.text;
//    }
//}