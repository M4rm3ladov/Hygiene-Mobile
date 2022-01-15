using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGerm : MonoBehaviour
{
    [SerializeField]
    private float minSpeedX, maxSpeedX, minSpeedY, maxSpeedY;
    [SerializeField]
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minSpeedX, maxSpeedX)
        , Random.Range(minSpeedY, maxSpeedY));
        
        Destroy(gameObject, lifeTime);
    }
}
