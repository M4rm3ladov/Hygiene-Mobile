using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController instance;

    [SerializeField]
    SkinsManager skinsManager;
    [SerializeField]
    Animator animTransition;
    [SerializeField]
    private float xLimit = .215f;
    [SerializeField]
    public float moveSpeed;
    private bool movingRight = true;
    private float direction = 0.045f;
    private bool startMoving = false;
    public bool StartMoving{ get{ return startMoving;} }
    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    private void Update() {  
        
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began){
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if(raycastResults.Count > 0){
                foreach(var go in raycastResults){
                    if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && 
                        go.gameObject.tag != "Player" &&
                        go.gameObject.tag != "Ground" && 
                        go.gameObject.tag != "Point" &&
                        go.gameObject.tag != "Life" &&
                        go.gameObject.tag != "Enemy" && 
                        go.gameObject.tag != "Effect")
                            return;
                }
            }      
        }

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && startMoving == false){
            startMoving = true;
        }

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && MenuManager.gameIsPaused > -1){
            movingRight = !movingRight;
            direction = -direction;
            transform.localScale = new Vector3(direction, 0.045f, 0.045f);
        }

        if(startMoving == false) return;

        ChangeDirection();
        transform.position += Vector3.right * moveSpeed * Time.deltaTime * direction; 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xLimit, xLimit), transform.position.y, transform.position.z);
        animTransition.SetBool("isWalking", startMoving);
    }
    private void ChangeDirection(){
        if(movingRight && transform.position.x >= xLimit){
            movingRight = false;
            direction = -0.045f;
            transform.localScale = new Vector3(direction, 0.045f, 0.045f);
        }
        if(!movingRight && transform.position.x <= -xLimit){
            movingRight = true;
            direction = 0.045f;
            transform.localScale = new Vector3(direction, 0.045f, 0.045f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Point")){
           MenuManager.instance.IncreaseScore();
           MenuManager.instance.IncreaseCoin();
        }
        else if(other.CompareTag("Enemy"))
            MenuManager.instance.DecreaseLife();
        else if(other.CompareTag("Life"))
            MenuManager.instance.IncreaseLife();
    }
}
