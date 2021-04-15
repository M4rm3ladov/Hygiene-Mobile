using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer BodyPart;
    [Header("Cycle Through")]
    public List<Sprite> SpriteOptions = new List<Sprite>();
    private int _currentOption = 0;
    public void NextOption()
    {
        _currentOption++;
        if(_currentOption >= SpriteOptions.Count)
        {
            _currentOption = 0;
        }
        BodyPart.sprite = SpriteOptions[_currentOption];
    }
    public void PreviousOption()
    {
        _currentOption--;
        if(_currentOption <= 0)
        {
            _currentOption = SpriteOptions.Count - 1;
        }
        BodyPart.sprite = SpriteOptions[_currentOption];
    }

}
