using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLoose : MonoBehaviour
{
    public Text victoire;
    public Text defaite;
    public Text continueButton;

    public bool actif = false;

    public static WinOrLoose Instance;
    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        actif = false;
        victoire.gameObject.SetActive(false);
        defaite.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!actif)
        {
            return;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Transition.Instance.LoadNextLevel();
            }
        }
    }

    public void Victoire()
    {
        if(actif)
        {
            return;
        }

        victoire.gameObject.SetActive(true);
        defaite.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        actif = true;
    }

    public void Defaite()
    {
        if (actif)
        {
            return;
        }

        victoire.gameObject.SetActive(false);
        defaite.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        actif = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            return;
        }

        if(GameMaster.Instance.listeDeCourse.Count == GameMaster.Instance.cadie.Count)
        {
            Victoire();
        }
    }
}