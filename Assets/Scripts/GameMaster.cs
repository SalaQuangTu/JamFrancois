using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int nbObjetsAChopper = 0;

    public List<string> listeDeCourse = new List<string>();
    [Space] public List<string> cadie = new List<string>();

    bool gotTheList = false;

    public SpawnShelves spawnShelves;

    public ListeDeCourse ldc;

    private void Update()
    {
        if(!gotTheList && (spawnShelves.numberOfShelves == spawnShelves.spawnPoints.Count))
        {
            GenererListeDeCourse(spawnShelves.GetGroceryType);
            gotTheList = true;
        }
    }

    public void GenererListeDeCourse(List<string> objetsDansLeMagasin)
    {
        if (nbObjetsAChopper > objetsDansLeMagasin.Count)
        {
            nbObjetsAChopper = objetsDansLeMagasin.Count;
        }

        for (int i = 0; i < nbObjetsAChopper; i++)
        {
            listeDeCourse.Add(objetsDansLeMagasin[i]);
        }

        ldc.CreationDeLaListe(listeDeCourse);
    }
}