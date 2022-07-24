using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject triggerBlock; // select the pink trigger block you design
    private GameObject player;
    public float waitBeforeUpTime = 0.5f;
    public float upDuration = 1f;
    private bool haveUp = false;
    private bool isMoving = false;
    // private float timeToMove = 0.6f;
    void Start()
    {
        player = GameObject.Find("Player");
        // Debug.Log(triggerBlock.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveUp == false && isMoving == false){
            // Debug.Log("")
            if (Vector3.Distance(player.transform.position, triggerBlock.transform.position+ new Vector3(0,0.5f,0)) <= 1.1) {
                // Debug.Log("poping");
                StartCoroutine(MoveEnemy(Vector3.up));
                SoundManager.PlayAppearClip();

                Invoke("delEnemy", upDuration);
                haveUp = true;
            }
        }
    }

    private IEnumerator MoveEnemy(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 originPos = transform.position;
        Vector3 targetPos = originPos + direction;

        while(elapsedTime < waitBeforeUpTime)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / waitBeforeUpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private void delEnemy(){
        StartCoroutine(MoveEnemy(Vector3.down));
        // transform.gameObject.SetActive(false);
    }
}
