using UnityEngine;

public class NeedsController : MonoBehaviour
{
    [SerializeField]
    private int _food, _cleanliness, _energy;
    [SerializeField]
    private int _foodTickRate, _cleanlinessTickRate, _energyTickRate;

    # region Initialization
    public int Food
    {
        set { _food = value;}
    }
    public int Cleanliness
    {
        set { _cleanliness = value;}
    }
    public int Energy
    {
        set { _energy = value;}
    }
    public int _FoodTickRate
    {
        set { _foodTickRate = value;}
    }
    public int _CleanlinessTickRate
    {
        set { _cleanlinessTickRate = value;}
    }
    public int _EnergyTickRate
    {
        set { _energyTickRate = value;}
    }
    #endregion
    private void Update() 
    {
        if(TimingManager.GameHourTimer < 0)
        {
            ChangeFood(-_foodTickRate);
            ChangeEnergy(-_energyTickRate);
            ChangeCleanliness(-_cleanlinessTickRate);
        }
    }

    #region UpdateNeeds
    public void ChangeFood(int amount)
    {
        _food += amount;
        if(_food < 0) CharManager.Famished();
        else if(_food > 100) _food = 100;       
    }
    public void ChangeCleanliness(int amount)
    {
        _cleanliness += amount;
        if(_cleanliness < 0) CharManager.Dirty();
        else if(_cleanliness > 100) _cleanliness = 100;
    }
    public void ChangeEnergy(int amount)
    {
        _energy += amount;
        if(_energy < 0) CharManager.Drowsed(); 
        else if(_energy >100) _energy = 100;    
    }
    #endregion
}
