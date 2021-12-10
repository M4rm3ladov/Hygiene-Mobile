using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    Animator animTransition;
    private void Start() {
        //if(PlayerPrefs.GetInt("gender") == 0)
            animTransition = GameObject.Find("Girl").GetComponent<Animator>();
        //else if(PlayerPrefs.GetInt("gender") == 1)
            //animationTransition = GameObject.Find("Girl").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")){
            GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("SmokeEffect");
            smokeEffect.transform.position = transform.position;
            smokeEffect.SetActive(true);
            smokeEffect.GetComponent<Animator>().Play("smoke", -1, 0);   

            int r = Random.Range(0, 10);
            if(r == 0){
                GameObject life = ObjectPooling.instance.GetPooledObject("Life");
                life.transform.position = transform.position;
                life.SetActive(true);
            }  
            gameObject.SetActive(false); 
        }
        if(other.CompareTag("Player")){
            if(gameObject.name == "Candy" || gameObject.name == "Chocolate" || gameObject.name == "Lollipop"){
                GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("SmokeEffect");
                smokeEffect.transform.position = transform.position;
                smokeEffect.SetActive(true);
                smokeEffect.GetComponent<Animator>().Play("smoke", -1, 0); 
                
                animTransition.SetTrigger("Damaged");
            }else{
                GameObject sparkleEffect = ObjectPooling.instance.GetPooledObject("sparkle");
                sparkleEffect.transform.position = transform.position;
                sparkleEffect.SetActive(true);
                sparkleEffect.GetComponent<Animator>().Play("sparkle", -1, 0); 
            }
            gameObject.SetActive(false);   
        }     
    }
    public void DeactivateHeart(){
        gameObject.SetActive(false);
    }
}
