using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleDown : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    private GameObject player;
    private float timeToMove = 0.5f;
    bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDown)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 1.1 && (player.transform.position.y == 2 && transform.position.y == 1))
            {

                if (player.GetComponent<PlayerController>().isMoving == false)
                {
                    player.GetComponent<PlayerController>().isMoving = true;
                    StartCoroutine(Move(Vector3.down, true));
                    // audio
                    SoundManager.PlayEleDownClip();

                    Invoke("waitforsecond", 1f);

                    isDown = true;
                    
                }
            }
        }
        else if (isDown && Vector3.Distance(player.transform.position, transform.position) > 1.5)
        {

            StartCoroutine(Move(Vector3.up, false));
            isDown = false;

        }
    }

    private IEnumerator Move(Vector3 direction, bool withplayer) // move block and player, if withplayer == false , without moving player
    {

        float elapsedTime = 0;
        Vector3 block_originPos = transform.position;
        Vector3 block_targetPos = block_originPos + direction;
        Vector3 player_originPos = player.transform.position;
        Vector3 player_targetPos = player_originPos + direction;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(block_originPos, block_targetPos, (elapsedTime / timeToMove));
            if (withplayer) player.transform.position = Vector3.Lerp(player_originPos, player_targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = block_targetPos;
        if (withplayer) player.transform.position = player_targetPos;
        // player.GetComponent<PlayerController>().isMoving = false;
    }

    private void waitforsecond()
    {
        player.GetComponent<PlayerController>().isMoving = false;
        return;
    }
}