using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailsManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> nails = new List<GameObject>();
    public List<GameObject> Nails{
       get{return nails;}
       set{nails = value;}
    }
}
