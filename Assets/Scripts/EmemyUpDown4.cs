using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyUpDown4 : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject triggerBlock; // select the pink trigger block you design
    private GameObject player;
    public GameObject hiddenEnemy;
    public GameObject targetBlock;
    public float waitBeforeUpTime = 0.5f;
    public float upDuration = 1f;
    private bool haveUp = false;
    private bool isMoving = false;
    private GameObject enemy;
    // private float timeToMove = 0.6f;
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = Instantiate(hiddenEnemy, targetBlock.transform.position, Quaternion.identity);
        // Debug.Log(enemy.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveUp == false && isMoving == false){
            if (Vector3.Distance(player.transform.position, transform.position) <= 1.1) {
              
                StartCoroutine(MoveEnemy(Vector3.up));
                Invoke("delEnemy", upDuration);
                haveUp = true;
            }
        }
    }

    private IEnumerator MoveEnemy(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 originPos = enemy.transform.position;
        Vector3 targetPos = originPos + direction;

        while(elapsedTime < waitBeforeUpTime)
        {
            enemy.transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / waitBeforeUpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        enemy.transform.position = targetPos;
        isMoving = false;
    }
    private void delEnemy(){
        StartCoroutine(MoveEnemy(Vector3.down));
        // transform.gameObject.SetActive(false);
    }
}
