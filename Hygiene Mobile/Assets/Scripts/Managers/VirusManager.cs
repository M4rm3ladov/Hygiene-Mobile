using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> virus = new List<GameObject>();
    public List<GameObject> Virus{
        get{ return virus;}
        set{ virus = value;}
    }
}
