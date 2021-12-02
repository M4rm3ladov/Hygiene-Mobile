using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float moveSpeed;
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
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && startMoving == false){
            startMoving = true;
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
}
