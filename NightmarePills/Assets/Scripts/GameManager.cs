using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Image pill1;
    private Image pill2;
    private Image alienHead;
    private Image alienBody;
    private TextMeshProUGUI scoretxt;
    private TextMeshProUGUI endScoreText;
    private GameObject gameUI;
    private GameObject endGameUI;

    public int score = 0;

    private Animator pillAnimator;

    private bool selected = false;
    public bool gameIsOver = false;

    private int redColor1 = 0;
    private int blueColor1 = 0;
    private int greenColor1 = 0;

    private int redColor2 = 0;
    private int blueColor2 = 0;
    private int greenColor2 = 0;

    private int[] possibleColors = new int[] { 0, 130, 255 };

    private int redColor3;
    private int blueColor3;
    private int greenColor3;

    private int redColor4;
    private int blueColor4;
    private int greenColor4;

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
    void Start()
    {
        pill1 = GameObject.Find("Pill1").GetComponent<Image>();
        pill2 = GameObject.Find("Pill2").GetComponent<Image>();
        alienBody = GameObject.Find("bodyAlien").GetComponent<Image>();
        alienHead = GameObject.Find("headAlien").GetComponent<Image>();
        pillAnimator = GameObject.Find("Pillfold").GetComponent<Animator>();
        scoretxt = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        gameUI = GameObject.Find("Game");
        endGameUI = GameObject.Find("EndGame");
        endScoreText = GameObject.Find("EndScore").GetComponent<TextMeshProUGUI>();

        endGameUI.SetActive(false);

        RandomizeAlien();
    }

    public void Select1()
    {
        AudioManager.instance.Play("selectColor");
        selected = false;
    }

    public void Select2()
    {
        AudioManager.instance.Play("selectColor");
        selected = true;
    }

    public void OnRedColor()
    {
        if (!selected)
        {
            redColor1 += 130;
            if (redColor1 >= 255)
            {
                redColor1 = 255;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        } else
        {
            redColor2 += 130;
            if (redColor2 >= 255)
            {
                redColor2 = 255;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("selectColor");
    }

    public void OnGreenColor()
    {
        if (!selected)
        {
            greenColor1 += 130;
            if (greenColor1 >= 255)
            {
                greenColor1 = 255;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            greenColor2 += 130;
            if (greenColor2 >= 255)
            {
                greenColor2 = 255;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("selectColor");
    }

    public void OnBlueColor()
    {
        if (!selected)
        {
            blueColor1 += 130;
            if (blueColor1 >= 255)
            {
                blueColor1 = 255;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            blueColor2 += 130;
            if (blueColor2 >= 255)
            {
                blueColor2 = 255;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("selectColor");
    }

    public void RemoveRed()
    {
        if (!selected)
        {
            if(redColor1 == 255)
            {
                redColor1 = 130;
            } else
            {
                redColor1 -= 130;
            }
            if (redColor1 <= 0)
            {
                redColor1 = 0;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            if (redColor2 == 255)
            {
                redColor2 = 130;
            }
            else
            {
                redColor2 -= 130;
            }
            redColor2 -= 130;
            if (redColor2 <= 0)
            {
                redColor2 = 0;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("removeColor");
    }

    public void RemoveGreen()
    {
        if (!selected)
        {
            if (greenColor1 == 255)
            {
                greenColor1 = 130;
            }
            else
            {
                greenColor1 -= 130;
            }
            if (greenColor1 <= 0)
            {
                greenColor1 = 0;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            if (greenColor2 == 255)
            {
                greenColor2 = 130;
            }
            else
            {
                greenColor2 -= 130;
            }
            if (greenColor2 <= 0)
            {
                greenColor2 = 0;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("removeColor");
    }

    public void RemoveBlue()
    {
        if (!selected)
        {
            if (blueColor1 == 255)
            {
                blueColor1 = 130;
            }
            else
            {
                blueColor1 -= 130;
            }
            if (blueColor1 <= 0)
            {
                blueColor1 = 0;
            }
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            if (blueColor2 == 255)
            {
                blueColor2 = 130;
            }
            else
            {
                blueColor2 -= 130;
            }
            if (blueColor2 <= 0)
            {
                blueColor2 = 0;
            }
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
        AudioManager.instance.Play("removeColor");
    }

    public void RandomizeAlien()
    {
        redColor3 = possibleColors[Random.Range(0, 3)];
        blueColor3 = possibleColors[Random.Range(0, 3)];
        greenColor3 = possibleColors[Random.Range(0, 3)];

        alienHead.color = new Color32((byte)redColor3, (byte)greenColor3, (byte)blueColor3, 255);

        redColor4 = possibleColors[Random.Range(0, 3)];
        blueColor4 = possibleColors[Random.Range(0, 3)];
        greenColor4 = possibleColors[Random.Range(0, 3)];

        alienBody.color = new Color32((byte)redColor4, (byte)greenColor4, (byte)blueColor4, 255);
    }

    public void Submit()
    {
        if((redColor1 == redColor3) && (blueColor1 == blueColor3) && (greenColor1 == greenColor3) && (redColor2 == redColor4) && (blueColor2 == blueColor4) && (greenColor2 == greenColor4))
        {
            ResetColors();
            RandomizeAlien();
            TimerManager.instance.ResetTimer();
            UpdateScore();
        }
        else
        {
            StartCoroutine(InvalidAnim());
            Debug.Log("Pas valide");
        }
        AudioManager.instance.Play("misc");
    }

    public void ResetColors()
    {
        AudioManager.instance.Play("misc");

        redColor1 = 0;
        blueColor1 = 0;
        greenColor1 = 0;
        pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);

        redColor2 = 0;
        blueColor2 = 0;
        greenColor2 = 0;
        pill2.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
    }

    public void ResetSelected()
    {
        AudioManager.instance.Play("misc");
        if (!selected)
        {
            redColor1 = 0;
            blueColor1 = 0;
            greenColor1 = 0;
            pill1.color = new Color32((byte)redColor1, (byte)greenColor1, (byte)blueColor1, 255);
        }
        else
        {
            redColor2 = 0;
            blueColor2 = 0;
            greenColor2 = 0;
            pill2.color = new Color32((byte)redColor2, (byte)greenColor2, (byte)blueColor2, 255);
        }
    }

    public void UpdateScore()
    {
        score += (int)(100 / (TimerManager.instance.gameTime / 2));
        scoretxt.text = "Score :" + score.ToString();

    }

    public void GameOver()
    {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        gameIsOver = true;

        endScoreText.text = "Your Score : " + score.ToString();
    }

    IEnumerator InvalidAnim()
    {
        pillAnimator.SetBool("Inval", true);
        yield return new WaitForSeconds(0.5f);
        pillAnimator.SetBool("Inval", false);
    }
}
