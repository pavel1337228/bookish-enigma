using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryScript : MonoBehaviour
{
    public List<item> Items;

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

    private void FixedUpdate()
    {
        DisplayItems();
    }

    //public void TakeFood()
    //{
    //    if (Input.GetKeyDown(TakeKey))
    //    {
    //        Vector3 origin = RayOrigin.transform.position;

    //        Collider[] hitColliders = Physics.OverlapSphere(origin, 2f);

    //        for (int i = 0; i < hitColliders.Length; i++)
    //        {
    //            if (hitColliders[i].gameObject.tag == "Item")
    //            {
    //                for (int k = 0; k < Items.Count; k++)
    //                {
    //                    if ((Items[k].Id == hitColliders[i].GetComponent<Food>().Id) && (Items[k].IsStacable == true))
    //                    {
    //                        Items[k].Count += 1;
    //                        TakeMessage(hitColliders[i].GetComponent<Food>());
    //                        Destroy(hitColliders[i].gameObject);
    //                        DisplayItems();
    //                        break;
    //                    }
    //                    else if (Items[k].Id == 0)
    //                    {
    //                        Items[k] = hitColliders[i].GetComponent<Food>();
    //                        Items[k].Count = 1;
    //                        TakeMessage(hitColliders[i].GetComponent<Food>());
    //                        Destroy(hitColliders[i].gameObject);
    //                        DisplayItems();
    //                        break;
    //                    }
    //                }
    //                break;
    //            }
    //        }
    //    }
    //}

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
        if (ToogleInv == true)
        {
            for (int i = 0; i < CellContainer.transform.childCount; i++)
            {
                //Transform cell = CellContainer.transform.GetChild(i);
                //Transform icon = cell.GetChild(0);
                //Image img = icon.GetComponent<Image>();
                //Transform count = cell.transform.GetChild(1);
                //Text countText = count.GetComponent<Text>();

                //if (Items[i].Id != 0)
                //{
                //    img.enabled = true;
                //    img.sprite = Items[i].Icon;

                //    if (Items[i].Count > 0)
                //    {
                //        countText.text = Items[i].Count.ToString();
                //    }
                //    else
                //    {
                //        countText.text = null;
                //    }
                //}
                //else
                //{
                //    img.enabled = false;
                //}

                if ((Items[i].Id != 0) && (Items[i].Count == 0))
                {
                    Items[i] = new item();
                    DisplayItems();
                }
            }

            Debug.Log("done");

            ToogleInv = false;
        }
    }
}
