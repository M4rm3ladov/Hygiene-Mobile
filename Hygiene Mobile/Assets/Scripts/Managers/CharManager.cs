using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    CharController charController;
    NeedsController needsController;
    private void Awake() {
        
    }
    #region Consequences
    public static void Famished()
    {
        Debug.Log("Famished");
    }
    public static void Drowsed()
    {
        Debug.Log("Drowsed");
    }
    public static void Dirty()
    {
        Debug.Log("Dirty");
    }
    #endregion
}
