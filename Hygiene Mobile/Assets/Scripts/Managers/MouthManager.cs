using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mouth = new List<GameObject>();
    public List<GameObject> Mouth{
        get{ return mouth; }
        set{ mouth = value;}
    }
}
