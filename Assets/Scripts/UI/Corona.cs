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
        coronaBar.value += personneDansMaZone * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        personneDansMaZone++;
    }

    private void OnTriggerExit(Collider other)
    {
        personneDansMaZone--;
    }
}
