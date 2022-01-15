using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private const float GRAVITY = 1f;
    public bool IsActive{get; set;}
    private float verticalVelocity;
    private float speed;
    public void LaunchGerms(float verticalVelocity, float xSpeed, float xStart){
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = new Vector3(xStart, -.3f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-.5f, .5f);
        LaunchGerms(Random.Range(.75f, 1f), randomX, -randomX);
        //Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsActive)
            return;
        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

        if(transform.position.y < -.5f){
            SliceManager.instance.DecreaseLife();
            IsActive = false;
            Destroy(gameObject);
        }
    }
    /*public void Slice(){
        if(verticalVelocity < .05f){
            verticalVelocity = .05f;
        }
        speed *= .05f;
    }*/
}
