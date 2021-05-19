using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    /*public Vector3 _startPosition;
    private void Start() {
        _startPosition = transform.position;
    }*/
    
    /*public bool IsDragging;
    public Vector3 LastPosition;
    private Collider2D _collider;
    private DragController _dragController;
    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    private void Start() {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }
    private void FixedUpdate() {
        if(_movementDestination.HasValue){
            if(IsDragging){
                _movementDestination = null;
                Debug.Log("first");
                return;
            }
            if(transform.position == _movementDestination){
                gameObject.layer = Layer.Default;
                _movementDestination = null;
                Debug.Log("second");
            }else{
                Debug.Log("has value");
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Draggable collidedDraggable = other.GetComponent<Draggable>();
        if(collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject){
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }    
        if(other.CompareTag("DropInvalid")){
            Debug.Log("valid");
            _movementDestination = other.transform.position;
            Debug.Log(_movementDestination);
        }else if(other.CompareTag("DropValid")){
            Debug.Log("invalid");
            _movementDestination = LastPosition;
        }
    }*/
    [SerializeField]
    FoodManager foodManager;
    [SerializeField]
    ConsumeFoodManager consumeFoodManager;
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
        if(isDragged)
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);       
    }
    private void OnMouseUp() 
    {
        isDragged = false;
        transform.position = spriteDragStartPosition;
        if(collided){
            Debug.Log("triggered");
            
            SubtractRemoveFoodItem();  
            CheckFoodStashCount(); 

            if(Player.BoughtFood.Count >= 1)
            {
                foreach (KeyValuePair<string, int> _key in Player.BoughtFood)   
                FoodIndex.Add(_key.Key);

                LoadFoodToTable();
            }      
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Head")
            collided = true;             
    }
    private void OnTriggerExit2D(Collider2D other) {
        collided = false;
    }
    private void LoadFoodToTable(){
        int foodSpriteOptionsIterator = 0;
        foreach (Sprite foodSprite in foodManager.FoodSpriteOptions)
        {
            if(foodSprite.name.ToString() == FoodIndex[0]){
                foodManager.Food.sprite = foodManager.FoodSpriteOptions[foodSpriteOptionsIterator];
                consumeFoodManager.ItemCount.text = Player.BoughtFood[FoodIndex[0]].ToString();
            }
            foodSpriteOptionsIterator++;
        }
    }
    private void SubtractRemoveFoodItem(){
        if(Player.BoughtFood[foodManager.Food.sprite.name] == 1){
            Player.BoughtFood.Remove(foodManager.Food.sprite.name);
            return;
        }
        Player.BoughtFood[foodManager.Food.sprite.name]--;
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
