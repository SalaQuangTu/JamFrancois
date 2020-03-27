using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int nbObjetsAChopper = 0;

    public List<string> listeDeCourse = new List<string>();
    [Space] public List<string> cadie = new List<string>();

    public SpawnShelves spawnShelves;


    private void Start()
    {
        GenererListeDeCourse(spawnShelves.GetGroceryType);
    }



    public void GenererListeDeCourse(List<string> objetsDansLeMagasin)
    {
        if(nbObjetsAChopper > objetsDansLeMagasin.Count)
        {
            nbObjetsAChopper = objetsDansLeMagasin.Count;
        }


    }
}