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
    public float Interval{get; set;}
    /*[SerializeField]
    private float minimumX;
    [SerializeField]
    private float maximumX;
    [SerializeField]
    private float y;*/
 
    [SerializeField]
    private Sprite[] sprites;
    private void Start() {
        InvokeRepeating("Spawn", interval, interval);
    }

    private void Spawn(){
        GameObject instance = Instantiate(prefab);
        //instance.transform.position = new Vector2(Random.Range(minimumX, maximumX), y);
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
