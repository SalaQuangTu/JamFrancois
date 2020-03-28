using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corona : MonoBehaviour
{
    public Slider coronaBar;
    public int valeurMaxAvantDeces = 100;
    public int personneDansMaZone = 0;

    private void Start()
    {
        personneDansMaZone = 0;
        coronaBar.maxValue = valeurMaxAvantDeces;
    }

    private void Update()
    {
        if (WinOrLoose.Instance.actif)
        {
            return;
        }

        coronaBar.value += personneDansMaZone * Time.deltaTime;

        if(coronaBar.value >= coronaBar.maxValue)
        {
            WinOrLoose.Instance.Defaite();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemi")
        {
            personneDansMaZone++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemi")
        {
            personneDansMaZone--;
        }
    }
}
