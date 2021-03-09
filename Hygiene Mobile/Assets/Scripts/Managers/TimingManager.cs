using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float GameHourTimer;
    [SerializeField]
    private float _hourLegnth;
    
    #region Properties
    public float HourLegnth{
        get { return _hourLegnth; }
        set { _hourLegnth = value; }
    }
    #endregion
    private void Update() 
    {
        if (GameHourTimer <= 0) 
        {
            GameHourTimer = _hourLegnth;
        }
        else
        {
            GameHourTimer -= Time.deltaTime;
        }
    }
}
