using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedsController : MonoBehaviour
{
    //Bar Image initialization
    [SerializeField] 
    private Image CurrentHygiene;
    [SerializeField]
    private Image CurrentHunger;
    //[SerializeField]
    //private Image CurrentEnergy;
    //Bar Text initialization
    [SerializeField]
    public Text HygieneText;
    [SerializeField]
    public Text HungerText;
    [SerializeField]
    //public Text EnergyText;
    //Maximum amount of a need
    private float _max = 100;
    //Satifiers Button initialization
    [SerializeField]
    private Button Feed;
    [SerializeField]
    private Button Hygiene;
    //[SerializeField]
    //private Button Play;
    //Bar tick rate initialization
    [SerializeField]
    private float _hygieneTickRate;
    [SerializeField]
    private float _hungerTickRate;
    //[SerializeField]
    //private float _energyTickRate;
    //[SerializeField]
    //private float _energyIncrease;
    // Start is called before the first frame update
    void Start()
    {
        Button btnHygiene = Hygiene.GetComponent<Button>();
        btnHygiene.onClick.AddListener(CleanTheChar);

        Button btnFeed = Feed.GetComponent<Button>();
        btnFeed.onClick.AddListener(FeedTheChar);

        //Button btnPlay = Play.GetComponent<Button>();
        //btnPlay.onClick.AddListener(RestTheChar);
    }

    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.GameHourTimer < 0)
        {
            ChangeHygiene();
            ChangeHunger();
            //ChangeEnergy();
        }  
        //Update UI
        UpdateCleanBar();
        UpdateHungerBar();
        //UpdateEnergyBar();
    }
    #region Reduce Needs
    private void ChangeHygiene()
    {
         Player.Hygiene -= _hygieneTickRate * Time.deltaTime;
        if(Player.Hygiene < 0 )
        {
            Player.Hygiene = 0;
        }
    }
    private void ChangeHunger()
    {
        Player.Hunger -= _hungerTickRate * Time.deltaTime;
        if(Player.Hunger < 0 )
        {
            Player.Hunger = 0;
        }
    }
    /*private void ChangeEnergy()
    {
        Player.Energy -= _energyTickRate * Time.deltaTime;
        if(Player.Energy < 0 )
        {
            Player.Energy = 0;
        }
    }*/
    #endregion
    #region Reduce Needs Bar
    private void UpdateCleanBar()
    {
        float ratio = Player.Hygiene / _max;
        CurrentHygiene.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HygieneText.text = (ratio * 100).ToString("0") + "%";
    }
    private void UpdateHungerBar()
    {
        float ratio = Player.Hunger / _max;
        CurrentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HungerText.text = (ratio * 100).ToString("0") + "%";
    }
    /*private void UpdateEnergyBar()
    {
        float ratio = Player.Energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }*/
    #endregion
    #region Satisfying Needs
    private void CleanTheChar()
    {
        Debug.Log("Clean clicked");
        Player.Hygiene += 10;
        if(Player.Hygiene > _max)
        {
            Player.Hygiene = _max;
        }
        UpdateCleanBar();
    }
    private void FeedTheChar()
    {
         Debug.Log("Feed clicked");
        Player.Hunger += 10;
        if(Player.Hunger > _max)
        {
            Player.Hunger = _max;
        }
        UpdateHungerBar();
    }
    /*public void RestTheChar()
    {
         Debug.Log("Energy clicked");
        Player.Energy += _energyIncrease;
        if(Player.Energy > _max)
        {
            Player.Energy = _max;
        }
        UpdateEnergyBar();
    }*/
    #endregion
}
