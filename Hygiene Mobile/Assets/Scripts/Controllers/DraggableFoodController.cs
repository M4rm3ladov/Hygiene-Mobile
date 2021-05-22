using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggableFoodController : MonoBehaviour
{
    [SerializeField]
    FoodManager foodManager;
    [SerializeField]
    ConsumeFoodManager consumeFoodManager;
    [SerializeField]
    ConsumeFoodController consumeFoodController;
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    HungerManager hungerManager;
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private bool collided = false;
    private List<string> FoodIndex = new List<string>();
    private void OnMouseDown() 
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }
    private void OnMouseDrag() 
    {   
        if(isDragged){
            consumeFoodManager.Left.GetComponent<Button>().interactable = false;
            consumeFoodManager.Right.GetComponent<Button>().interactable = false;
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);       
        }
    }
    private void OnMouseUp() 
    {
        consumeFoodManager.Left.GetComponent<Button>().interactable = true;
        consumeFoodManager.Right.GetComponent<Button>().interactable = true;
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided){
            FeedTheChar();
            SubtractOrRemoveFoodItem();  
            CheckFoodStashCount();      
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Head")
            collided = true;             
    }
    private void OnTriggerExit2D(Collider2D other) {
        collided = false;
    }
    private void FeedTheChar(){
        int foodSpriteOptionsIterator = 0;
        foreach (Sprite foodSprite in foodManager.FoodSpriteOptions)
        {
            playerController.AnimTransition.SetTrigger("Eat");
            if(foodSprite.name.ToString() == consumeFoodController.FoodIndex[consumeFoodController.CurrentOption])
            {
                Player.Hunger += foodManager.FoodStats[foodSpriteOptionsIterator];
                hungerManager.UpdateHungerBar();
            }
                
            foodSpriteOptionsIterator++;
        }
    }
    private void SubtractOrRemoveFoodItem(){
        Player.BoughtFood[foodManager.Food.sprite.name]--;     

        if(Player.BoughtFood[foodManager.Food.sprite.name] < 1){
            consumeFoodController.FoodIndex.RemoveAt(consumeFoodController.CurrentOption);
            Player.BoughtFood.Remove(foodManager.Food.sprite.name);

            if(Player.BoughtFood.Count >= 1)    
                consumeFoodController.NextOption();
         
            return;
        }
        consumeFoodManager.ItemCount.text = (int.Parse(consumeFoodManager.ItemCount.text) - 1).ToString();
    }
    private void CheckFoodStashCount(){
        if(Player.BoughtFood.Count == 0){
            consumeFoodManager.Meal.SetActive(false);
            consumeFoodManager.ItemCountUI.SetActive(false);      
        }          
        if(Player.BoughtFood.Count <= 1){
            consumeFoodManager.Left.SetActive(false);
            consumeFoodManager.Right.SetActive(false);
        }
    }
}
