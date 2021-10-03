using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    private Slider timerSlider;
    private Image fillcolor;
    public float gameTime;
    private float initialGametime;


    private bool stopTimer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timerSlider = GameObject.Find("TimerSlider").GetComponent<Slider>();
        fillcolor = GameObject.Find("Filltimer").GetComponent<Image>();

        stopTimer = false;
        initialGametime = 15;
        gameTime = initialGametime;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        fillcolor.color = new Color32(0, 255, 0, 255);

    }

    // Update is called once per frame
    void Update()
    {
        if (!stopTimer)
        {
            gameTime -= Time.deltaTime;
            if (timerSlider.value >= (timerSlider.maxValue * 0.6))
            {
                fillcolor.color = new Color32(0, 255, 0, 255);
            } else if(((timerSlider.value < (timerSlider.maxValue * 0.6)) && (timerSlider.value > (timerSlider.maxValue * 0.3)))){
                fillcolor.color = new Color32(255, 130, 0, 255);
            } else
            {
                fillcolor.color = new Color32(255, 0, 0, 255);
            }
            timerSlider.value = gameTime;
        }

        if (gameTime <= 0)
        {
            stopTimer = true;
            GameManager.instance.GameOver();
        }

    }

    public void ResetTimer()
    {
        stopTimer = true;
        initialGametime -= 2;

        if(initialGametime <= 8)
        {
            initialGametime = 8;
        }

        gameTime = initialGametime;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

        fillcolor.color = new Color32(0, 255, 0, 255);
        stopTimer = false;
    }
}
