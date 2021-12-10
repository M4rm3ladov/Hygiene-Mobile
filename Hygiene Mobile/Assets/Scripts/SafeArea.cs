using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnOrientation : MonoBehaviour
{
    /*private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
    }*/
    private void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Catch"){
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.orientation = ScreenOrientation.Portrait;     
        }else{
            Screen.autorotateToPortrait = false;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToLandscapeLeft = true;
            //Screen.orientation = ScreenOrientation.AutoRotation; 
        }
            
    }

    /*RectTransform Panel;
    Rect LastSafeArea = new Rect(0, 0, 0, 0);
    private void Awake() {
        Panel = GetComponent<RectTransform>();
        Refresh();
    }
    // Update is called once per frame
    void Update()
    {
        Refresh();
    }
    void Refresh(){
        Rect safeArea = GetSafeArea();
        if(safeArea != LastSafeArea)
            ApplySafeArea(safeArea);
    }
    Rect GetSafeArea(){
        return Screen.safeArea;
 
    }
    void ApplySafeArea(Rect r){
        LastSafeArea = r;
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;
    }*/
}
