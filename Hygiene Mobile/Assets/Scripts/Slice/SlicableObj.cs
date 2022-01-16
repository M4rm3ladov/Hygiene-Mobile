using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableObj : MonoBehaviour
{
    [SerializeField]
    private GameObject smokePrefab;
    [SerializeField]
    private GameObject sparklePrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Cut"){
            if(gameObject.tag == "Life"){
                SliceManager.instance.IncreaseLife();
                Destroy(gameObject);

                GameObject sparkleEffect = Instantiate(sparklePrefab);
                sparkleEffect.transform.position = transform.position;
                sparkleEffect.SetActive(true);
                sparkleEffect.GetComponent<Animator>().Play("sparkle", -1, 0);  

                FindObjectOfType<AudioManager>().Play("Life"); 
                return;
            }else if(gameObject.tag == "Enemy"){
                GameObject smokeEffect = Instantiate(smokePrefab);
                smokeEffect.transform.position = transform.position;
                smokeEffect.SetActive(true);
                smokeEffect.GetComponent<Animator>().Play("smoke", -1, 0);

                FindObjectOfType<AudioManager>().Play("Poof");    
            }
            SliceManager.instance.IncreaseScore();
            SliceManager.instance.IncreaseCoin();
            Destroy(gameObject);
        }
    }
}
