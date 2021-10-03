using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private Image image;
    private int redColor = 0;
    private int blueColor = 0;
    private int greenColor = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnRedColor()
    {
        redColor += 130;
        if(redColor >= 255)
        {
            redColor = 255;
        }
        image.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
    }

    public void OnGreenColor()
    {
        greenColor += 130;
        if (greenColor >= 255)
        {
            greenColor = 255;
        }
        image.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
    }

    public void OnBlueColor()
    {
        blueColor += 130;
        if(blueColor >= 255)
        {
            blueColor = 255;
        }
        image.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
    }
}
