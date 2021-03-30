using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryScript : MonoBehaviour
{
    public List<item> Items;

    [Header("TEST AXE")]
    public GameObject Axe;

    public bool ToogleInv = false;
    
    [Header("Inventory")]
    public GameObject CellContainer;
    public GameObject Inventory;

    //[Header("Message")]
    //public GameObject MessageManager;
    //public GameObject Message;

    private void Start()
    {
        Items = new List<item>();

        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            Items.Add(new item());
        }
    }

    public void TakeFood()
    { 
        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            if (Items[i].Id == 0)
            {
                Items[i] = Axe.GetComponent<item>();
                DisplayItems();
                break;
            } 
        }
    }

    //public void TakeMessage(Food item)
    //{
    //    GameObject msg = Instantiate(Message);
    //    msg.transform.SetParent(MessageManager.transform);

    //    Image msgImg = msg.transform.GetChild(0).GetComponent<Image>();
    //    msgImg.sprite = item.Icon;

    //    Text msgText = msg.transform.GetChild(1).GetComponent<Text>();
    //    msgText.text = item.ItemName;
    //}

    public void DisplayItems()
    {
        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            Transform cell = CellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(1);
            Image img = icon.GetComponent<Image>();
            //Transform count = cell.transform.GetChild(1);
            //Text countText = count.GetComponent<Text>();

            if (Items[i].Id != 0)
            {
                img.enabled = true;
                img.sprite = Items[i].Icon;

                //if (Items[i].Count > 0)
                //{
                //    countText.text = Items[i].Count.ToString();
                //}
                //else
                //{
                //    countText.text = null;
                //}
            }
            else
            {
                img.enabled = false;
            }

            //if ((Items[i].Id != 0) && (Items[i].Count == 0))
            //{
            //    Items[i] = new item();
            //    DisplayItems();
            //}
        }

        Debug.Log("done");

        ToogleInv = false;
    }
}
