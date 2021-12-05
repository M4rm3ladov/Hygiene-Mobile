using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animTransition;
    private void Start() {
        //if(PlayerPrefs.GetInt("gender") == 0)
            animTransition = GameObject.Find("Boy").GetComponent<Animator>();
        //else if(PlayerPrefs.GetInt("gender") == 1)
            //animationTransition = GameObject.Find("Girl").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")){
            GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("smokeEffect");
            smokeEffect.transform.position = transform.position;
            smokeEffect.SetActive(true);
            smokeEffect.GetComponent<Animator>().Play("smoke", -1, 0);
            gameObject.SetActive(false);   
        }
        if(other.CompareTag("Player")){
            Debug.Log(gameObject.name);
            if(gameObject.name == "candy" || gameObject.name == "chocolate" || gameObject.name == "lollipop"){
                GameObject smokeEffect = ObjectPooling.instance.GetPooledObject("smokeEffect");
                smokeEffect.transform.position = transform.position;
                smokeEffect.SetActive(true);
                smokeEffect.GetComponent<Animator>().Play("smoke", -1, 0); 
                
                animTransition.SetTrigger("Damaged");
            }else{
                GameObject sparkleEffect = ObjectPooling.instance.GetPooledObject("sparkleEffect");
                sparkleEffect.transform.position = transform.position;
                sparkleEffect.SetActive(true);
                sparkleEffect.GetComponent<Animator>().Play("sparkle", -1, 0); 
            }
            gameObject.SetActive(false);   
        }      
    }
}
