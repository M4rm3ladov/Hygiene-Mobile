using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [Header("Food")]
    public SpriteRenderer Food;
    [Header("Cycle Through")]
    public List<Sprite> FoodSpriteOptions = new List<Sprite>();
    [Header("Food Prices")]
    public List<float> FoodPrices = new List<float>();
    [Header("Food Stats")]
    public List<float> FoodStats = new List<float>();
}
