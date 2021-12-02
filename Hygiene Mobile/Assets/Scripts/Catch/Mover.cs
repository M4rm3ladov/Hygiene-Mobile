using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
