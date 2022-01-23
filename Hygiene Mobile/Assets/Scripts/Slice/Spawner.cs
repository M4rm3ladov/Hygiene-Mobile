using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject heartPref;
    [SerializeField]
    private float interval;
    public float Interval{ get{ return interval;} set{ interval = value;} }
    private float currentTime;
 
    [SerializeField]
    private Sprite[] sprites;
    private void Start() {
        currentTime = interval;
        //Spawn();
        //InvokeRepeating("Spawn", interval, interval);
    }
    private void Update() {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            currentTime = interval;
            Spawn();
        }
       
    }

    private void Spawn(){
        GameObject instance = Instantiate(prefab);
        
        instance.transform.SetParent(transform);
        int heartRand = Random.Range(0, 20);
        if(heartRand == 0){
            GameObject heartInstance = Instantiate(heartPref);
            return;
        }

        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
    
}
