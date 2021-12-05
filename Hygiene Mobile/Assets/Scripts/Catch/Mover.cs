using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public static Mover instance;
    private float speed  = .1f;
    public float Speed{ get{ return speed; } }
    private void Awake() {
        if(instance == null) 
            instance = this;
    }
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
