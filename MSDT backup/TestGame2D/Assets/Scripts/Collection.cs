using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collection : MonoBehaviour {

    //public const int sizeOfItem = 30;
    public int nrOfItems;

    public Sprite[] sprites;
    public Sprite uncollected;
    public GameObject fieldItem;
    public GameObject collectionItem;

    public GameObject itemFoundParticle;

    private int nrOfItemsCollected;
    private GameObject[] items;

    // Use this for initialization
    void Start() {

        nrOfItems = gameObject.transform.childCount;
        items = new GameObject[nrOfItems];
        nrOfItemsCollected = 0;

        for (int i = 0; i < nrOfItems; i++) {

            // CREATE FIELD ITEM
            Vector3 positionItem = transform.position;
            
            // To spread out the items
            //positionItem.x = Random.Range(1, 15);
            //positionItem.y = Random.Range(2, 8);
            // For easier testing:
            positionItem.x = Random.Range(7, 9);
            positionItem.y = Random.Range(4, 6);

            GameObject newFieldItem = Instantiate(fieldItem);
            newFieldItem.tag = "Item";
            newFieldItem.GetComponent<Transform>().position = positionItem;
            newFieldItem.GetComponent<ItemField>().sprite = sprites[i];

            // CREATE COLLECTION ITEM
            items[i] = GameObject.Find("Item" + i);
            items[i].GetComponent<ItemCollection>().fieldItem = newFieldItem;
            items[i].GetComponent<ItemCollection>().transform.Find("ItemImage").GetComponent<Image>().sprite = uncollected;

            // Make sure the items are in the correct order in the hierarchy of the collection
            items[i].transform.SetSiblingIndex(i); 

        }

    }

    public void itemCollected(GameObject itemCollected) {

        for (int i = 0; i < nrOfItems; i++) {

            ItemCollection collectionItem = items[i].GetComponent<ItemCollection>();

            if (collectionItem.fieldItem == itemCollected) {
                
                // Set the item in the collection to collected
                collectionItem.collected();
                
                // Remove the field item
                Object.Destroy(itemCollected);

                // Check if all objects are collected
                nrOfItemsCollected++;
                checkIfDone();

                return;
            }

        }

    }

    private void checkIfDone() {
        if (nrOfItemsCollected == nrOfItems) {
            Instantiate(itemFoundParticle);
        }
    }


}
