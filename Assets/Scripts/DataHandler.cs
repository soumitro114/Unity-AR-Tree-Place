using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DataHandler : MonoBehaviour
{
    private GameObject treez;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;

    private int current_id = 0;
    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    private void Start()
    {
        LoadItems();
        CreateButton();
    }

    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Trees", typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
    }    
    
    void CreateButton()
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = current_id;
            b.ButtonTexture = i.itemimage;
            current_id++;
        }
        buttonContainer.GetComponent<UIContentFitter>().Fit();
    }

    public void SetTrees(int id)
    {
        treez = items[id].itemPreFab;
    }

    public GameObject GetTreez()
    {
        return treez;
    }

}
