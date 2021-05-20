using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    //public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private DraggableFoodController _lastDragged;
    
    private void Awake() 
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if(controllers.Length > 1)
            Destroy(gameObject);        
    }
    private void Update() {
        if(_isDragActive){
            if(Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)){
                Debug.Log("dropped");
                Drop();
                return;
            }
        }
        if(Input.GetMouseButton(0)){
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }else if(Input.touchCount > 0){
            _screenPosition = Input.GetTouch(0).position;
        }else{
            return;
        }
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
        if(_isDragActive)
            Drag();
        else{
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null){
                DraggableFoodController draggable = hit.transform.gameObject.GetComponent<DraggableFoodController>();
                if(draggable != null){
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }
    void InitDrag(){
        //_lastDragged.LastPosition = _lastDragged.transform.position;
        //UpdateDragStatus(true);
        _isDragActive = true;
    }
    void Drag(){
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }
    void Drop(){
        //UpdateDragStatus(false);
        _isDragActive = false;
        //_lastDragged.transform.position = new Vector2(_lastDragged._startPosition.x, _lastDragged._startPosition.y);
    }
    /*void UpdateDragStatus(bool isDragging){
        _isDragActive = _lastDragged.IsDragging = isDragging;
       _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }*/
    
}
