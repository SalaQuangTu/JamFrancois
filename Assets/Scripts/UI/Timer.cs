using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60f;
    public Text timerText;

    [Space]
    public int fontSize1 = 90;
    public Color color1 = Color.black;

    [Space]
    public int fontSize2 = 180;
    public Color color2 = Color.yellow;

    [Space]
    public int fontSize3 = 360;
    public Color color3 = Color.red;

    private int intActualTime;
    private float actualTime;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(WinOrLoose.Instance.actif)
        {
            return;
        }

        if(actualTime <= 0)
        {
            WinOrLoose.Instance.Defaite();
            return;
        }

        actualTime -= Time.deltaTime;

        if (actualTime <= timer / 4)
        {
            timerText.fontSize = fontSize3;
            timerText.color = color3;
        }
        else if(actualTime <= timer/2)
        {
            timerText.fontSize = fontSize2;
            timerText.color = color2;
        }
        else
        {
            timerText.fontSize = fontSize1;
            timerText.color = color1;
        }

        timerText.text = "Timer : " + Mathf.RoundToInt(actualTime);
    }
}
