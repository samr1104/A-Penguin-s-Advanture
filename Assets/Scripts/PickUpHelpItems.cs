using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHelpItems : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Debug.Log("before pick up:");
            // inventory.CheckFull();
            // for(int i = 0; i < inventory.slots.Length; i++)
            // {
            //     if(inventory.isFull[i] == false)
            //     {
            //         // Item can be added to inventory!
            //         inventory.isFull[i] = true;
            //         // Debug.Log("should be true: Check " + inventory.isFull[i]);
            //         // inventory.CheckFull();
            //         Instantiate(itemButton, inventory.slots[i].transform, false);
            //         Destroy(gameObject);
            //         break;
            //     }
            // }
            // Debug.Log("after pick up:");
            // inventory.CheckFull();

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    // audio
                    SoundManager.PlayPickUpItemClip();
                    // inventory.stars += 1;
                    inventory.isFull[i] = true;
                    // Instantiate(itemButton, inventory.slots[i].transform, false);
                    GameObject newButton = Instantiate(itemButton, inventory.slots[i].transform, false);
                    newButton.SetActive(true);
                    Destroy(gameObject);
                    player.gameObject.GetComponent<PlayerController>().itemPickup = player.gameObject.GetComponent<PlayerController>().itemPickup + 1;
                    // Debug.Log("Now have "+player.gameObject.GetComponent<PlayerController>().itemPickup);
                    break;
                }
            }
        }
    }
}
