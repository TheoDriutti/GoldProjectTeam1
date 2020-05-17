﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject objets;
    public Inventory inventory;

    List<GameObject> listeObjets;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            listeObjets = new List<GameObject>();
            GetObjets(4);
            DonneItems();
        }
    }

    void DonneItems()
    {
        foreach (GameObject gobj in listeObjets)
        {
            inventory.AddItem(gobj.GetComponent<IInventoryItem>());
        }
    }

    void GetObjets(int nbItems)
    {
        List<int> alreadyPicked = new List<int>();
        for (int i = 0; i < nbItems; i++)
        {
            int numeroItem = Random.Range(0, objets.transform.childCount);
            while (alreadyPicked.Contains(numeroItem))
            {
                numeroItem = Random.Range(0, objets.transform.childCount);
            }
            alreadyPicked.Add(numeroItem);

            Transform child = objets.transform.GetChild(numeroItem);
            listeObjets.Add(child.gameObject);
        }
    }
}