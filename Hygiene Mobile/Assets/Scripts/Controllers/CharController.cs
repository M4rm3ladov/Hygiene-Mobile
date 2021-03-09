using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimator;
    private void Awake() {

    }
    #region Animation
    public void Walk(){
        _characterAnimator.SetTrigger("Walk");
    }
    public void Eat(){
        _characterAnimator.SetTrigger("Eat");
    }
    public void Wave(){
        _characterAnimator.SetTrigger("Happy");
    }
    #endregion

}
