using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int nbObjetsAChopper = 0;

    public List<string> listeDeCourse = new List<string>();
    [Space] public List<string> cadie = new List<string>();

    public void GenererListeDeCourse(string[] objetsDansLeMagasin)
    {
        foreach(string objet in objetsDansLeMagasin)
        {
            if(Random.Range(0f,1f) <= 0.5f)
            {
                listeDeCourse.Add(objet);
            }
            
            if(listeDeCourse.Count == nbObjetsAChopper)
            {
                break;
            }
        }

        if(listeDeCourse.Count < nbObjetsAChopper)
        {
            while (listeDeCourse.Count < nbObjetsAChopper)
            {
                foreach (string objet in objetsDansLeMagasin)
                {
                    foreach(string objetChoisi in listeDeCourse)
                    {
                        if(objet != objetChoisi)
                        {
                            listeDeCourse.Add(objetChoisi);
                            break;
                        }
                    }

                    if (listeDeCourse.Count == nbObjetsAChopper)
                    {
                        break;
                    }
                }
            }
        }
    }
}