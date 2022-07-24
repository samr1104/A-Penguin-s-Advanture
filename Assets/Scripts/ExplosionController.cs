using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private GameObject player;
    private HeartSystem playerHearts;

    private bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHearts = player.GetComponent<HeartSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(!exploded)
        {
            // Debug.Log("hit something!");
            if (other.CompareTag("Player"))
            {
                // Debug.Log("explode: player");
                playerHearts.TakeDamage();
            }

            // if (other.CompareTag("Enemy"))
            // {
            //     Debug.Log("colide");
            //     // Destroy(other.gameObject);
            //     // Debug.Log("explode: enemy");
            //     // player.GetComponent<PlayerController>().enemyKill = player.GetComponent<PlayerController>().enemyKill + 1;
            //     // Debug.Log("current killing: " + player.GetComponent<PlayerController>().enemyKill);
            // }

            exploded = true;
        }
        
    }
}
