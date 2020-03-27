using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListeDeCourse : MonoBehaviour
{
    public Text itemTemplate;

    public List<Text> ldc = new List<Text>();

    [SerializeField]
    string itemAEnlever;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("ca marche");
            MajDeLaListe(itemAEnlever);
        }
    }

    public void CreationDeLaListe(List<string> listeAFaire)
    {
        foreach(string s in listeAFaire)
        {
            Text newItem = Instantiate(itemTemplate) as Text;
            newItem.gameObject.SetActive(true);
            newItem.gameObject.transform.SetParent(this.transform, true);
            ldc.Add(newItem);
            newItem.text = s;
        }
    }

    public void MajDeLaListe(string item)
    {
        foreach(Text s in ldc)
        {
            if(s.text == item)
            {
                s.gameObject.SetActive(false);
                ldc.Remove(s);
                GameMaster.Instance.cadie.Add(s.text);
                break;
            }
        }
    }
}