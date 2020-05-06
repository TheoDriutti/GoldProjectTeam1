using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> objectStored;
    public List<GameObject> buttons;
    public GameObject inventaire;
    public static ItemManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        for (int i = 0; i < inventaire.transform.childCount ; i++)
        {
            buttons.Add(inventaire.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<ItemsStored>().itemstored == null)
            {
                buttons[i].GetComponent<ItemsStored>().itemstored = objectStored[0];
                objectStored.Add(objectStored[0]);
                objectStored.RemoveAt(0);
            }
        }
    }

    
}
