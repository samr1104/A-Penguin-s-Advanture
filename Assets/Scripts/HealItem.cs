using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealItem : MonoBehaviour
{
    // player position
    private Transform player;

    private Vector3 slot1;
    private Vector3 slot2;
    private Vector3 slot3;

    // public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            slot1 = GameObject.Find("Slot(1)").transform.position;
            if(transform.position == slot1)
            {
                Use();
                // inventory.isFull[0] = false;
            }
        } else if(Input.GetKeyDown(KeyCode.K)) {
            slot2 = GameObject.Find("Slot(2)").transform.position;
            if(transform.position == slot2)
            {
                Use();
                // inventory.isFull[1] = false;
            }
        } else if(Input.GetKeyDown(KeyCode.L)) {
            slot3 = GameObject.Find("Slot(3)").transform.position;
            if(transform.position == slot3)
            {
                Use();
                // inventory.isFull[2] = false;
            }
        }
    }

    public void Use()
    {
        player.gameObject.GetComponent<HeartSystem>().GetHeal();
        Destroy(gameObject);
    }
}
