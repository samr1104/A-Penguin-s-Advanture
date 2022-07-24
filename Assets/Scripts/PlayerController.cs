using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Services.Core;
// using Unity.Services.Analytics;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask stopMovement;
    public float rayLength = 1.4f;
    public Vector3 direction;

    // used in SingleLevel
    public bool playVictoryAnimation = false;
    public CapsuleCollider destinationTrigger;

    public LayerMask water;

    public LayerMask Ice;
    public float originSpeed = 1f;
    public float speedIncrease = 0.5f;

    public Inventory inventory;

    public int currentLevel = 0;
    // public int enemyKill = 0;
    public int numEnemy;
    public int itemPickup = 0;

    private string url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdGOqN5DYsR79HX0byJl7bJ_Eqo7aVJPFN7Mr1ObypHP7n9wg/formResponse";
    public Animator ani;
    // private GameObject light;
    private int UP = 0;//角色状态向前

    private int RIGHT =1;//角色状态向右

    private int DOWN = 2;//角色状态向后

    private int LEFT = 3;//角色状态向左
    private int State = 1;
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        ani = GetComponent<Animator>();
        // light = GameObject.Find("Directional Light"); 
        // light.SetActive(false);
        // enemyKill = 0;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemy = allEnemies.Length;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            transform.GetComponent<HeartSystem>().GetHeal();
        }
        // if (isMoving == false){
        //     ani.SetBool("Walk",false);
        //   ani.SetBool("Idle", true);
        // }
        if (Physics.Raycast(transform.position, Vector3.down, rayLength, Ice) && !isMoving)
        {
            Vector3 target = transform.position;
            while (Physics.Raycast(target, Vector3.down, rayLength, Ice)) target = target + direction;
            if (Physics.Raycast(target - direction, direction, 1f, stopMovement)) target = target - direction;
            // Debug.Log(target);
            if (transform.position!=target) StartCoroutine(SlipOnIce(target));
        }

      if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isMoving)
      {
        int rotateValue = (UP - State) * 90;
        transform.Rotate(Vector3.up, rotateValue);
        State = UP;
          if(!Physics.Raycast(transform.position, Vector3.forward, rayLength, (stopMovement | water)))
          {
              direction = Vector3.forward;
              RaycastHit hit;
            //   Debug.Log("111");
              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){ // detect box in the direction
                  //push box;
        
                  PushBox(hit);
                  // audio
                  SoundManager.PlayPushBoxClip();
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoving)
      {
        int rotateValue = (DOWN - State) * 90;
        transform.Rotate(Vector3.up, rotateValue);
        State = DOWN;
          if(!Physics.Raycast(transform.position, Vector3.back, rayLength, (stopMovement | water)))
          {
              direction = Vector3.back;
              RaycastHit hit;

              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
            
                  PushBox(hit);
                  // audio
                  SoundManager.PlayPushBoxClip();
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isMoving)
      {
        int rotateValue = (LEFT - State) * 90;
        transform.Rotate(Vector3.up, rotateValue);
        State = LEFT;
          if(!Physics.Raycast(transform.position, Vector3.left, rayLength, (stopMovement | water)))
          {
              direction = Vector3.left;
              RaycastHit hit;

              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
             
                  PushBox(hit);
                  // audio
                  SoundManager.PlayPushBoxClip();
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isMoving)
      {
        int rotateValue = (RIGHT - State) * 90;
        transform.Rotate(Vector3.up, rotateValue);
        State =RIGHT;
          if(!Physics.Raycast(transform.position, Vector3.right, rayLength, (stopMovement | water)))
          {
              direction = Vector3.right;
              RaycastHit hit;
              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
           
                  PushBox(hit);
                  // audio
                  SoundManager.PlayPushBoxClip();
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
          // inventory.CheckFull();
      }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        ani.SetBool("Idle", false);
        ani.SetBool("Walk",true);
        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        
        ani.SetBool("Walk",false);
        ani.SetBool("Idle", true);
        isMoving = false;
    }

    private IEnumerator SlipOnIce(Vector3 target)
    {
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position - new Vector3(0,1,0), direction,out hit,Mathf.Infinity)){
        //     Debug.Log(hit.collider.transform.position);
        // }

        // Vector3 target = transform.position + direction;

        isMoving = true;

        // audio
        SoundManager.PlaySlideClip();

        // Vector3 originPos = transform.position;
        // targetPos = originPos + direction;
        float speed = originSpeed;
        while (transform.position != target)
        {
            speed += speedIncrease;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;

        isMoving = false;

    }

    private void PushBox(RaycastHit hit)
    {
        // // check if it is moveable and push box
        // hit.collider.GetComponent<BoxController>().checkMoveable(direction);
        // if (hit.collider.GetComponent<BoxController>().moveable)
        // {
        //     StartCoroutine(MovePlayer(direction));
        //     hit.collider.GetComponent<BoxController>().move = true;
        // }

        // check if it is moveable and push box
        bool moveable = hit.collider.GetComponent<BoxController>().checkMoveable(direction);
        if (moveable) {
            //StartCoroutine(MovePlayer(direction));
            //hit.collider.GetComponent<BoxController>().moveBox(direction);
            //hit.collider.GetComponent<BoxController>().limitSteps--;

            isMoving = true;
            hit.collider.GetComponent<BoxController>().moveBox(direction);
            StartCoroutine(MovePlayer(direction));
            hit.collider.GetComponent<BoxController>().limitSteps--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player is inside destination trigger play victory clip
        if (other == destinationTrigger)
        {
            //playVictoryAnimation = true;
            //gameObject.SetActive(false);

            //Analytics.CustomEvent("UserData", new Dictionary<string, object>{{"Kill", enemyKill}, {"Item", itemPickup}, {"Level", currentLevel}});

            GameObject[] aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            int enemyKill = numEnemy - aliveEnemies.Length;

            playVictoryAnimation = true;
            // audio
            SoundManager.PlayWinClip();
            // StartCoroutine(Post());
            gameObject.SetActive(false);
            WWWForm form = new WWWForm();
            form.AddField("entry.445623165", currentLevel + " " + enemyKill + " " + itemPickup);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            www.SendWebRequest();

            Debug.Log("kill enemy: " + enemyKill);
        }
    }
    public bool FreezePlayer(){
        if (isMoving == false) {
            isMoving = true;
            Debug.Log("Freeze success");
            return true;
        }
        else return false;
    }
    public void UnfreezePlayer(){
        isMoving = false;
    }
}

