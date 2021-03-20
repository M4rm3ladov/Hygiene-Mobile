using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Needs : MonoBehaviour
{
    //Bar Image initialization
    [SerializeField] 
    private Image CurrentHygiene;
    [SerializeField]
    private Image CurrentHunger;
    [SerializeField]
    private Image CurrentEnergy;
    //Bar Text initialization
    [SerializeField]
    public Text HygieneText;
    [SerializeField]
    public Text HungerText;
    [SerializeField]
    public Text EnergyText;
    //Default bar initialization
    private float _hygiene = 100;
    private float _hunger = 100;
    private float _energy = 100;
    private float _max = 100;
    //Satifiers Button initialization
    [SerializeField]
    private Button Feed;
    [SerializeField]
    private Button Hygiene;
    [SerializeField]
    private Button Play;
    //Bar tick rate initialization
    [SerializeField]
    private float _hygieneTickRate;
    [SerializeField]
    private float _hungerTickRate;
    [SerializeField]
    private float _energyTickRate;
    // Start is called before the first frame update
    void Start()
    {
        Button btnHygiene = Hygiene.GetComponent<Button>();
        btnHygiene.onClick.AddListener(CleanTheChar);

        Button btnFeed = Feed.GetComponent<Button>();
        btnFeed.onClick.AddListener(FeedTheChar);

        Button btnPlay = Play.GetComponent<Button>();
        btnPlay.onClick.AddListener(PlayTheChar);
    }

    // Update is called once per frame
    void Update()
    {   
        //Reduce needs values per time passing of gameHour
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeHygiene();
            ChangeHunger();
            ChangeEnergy();
        }  
        //Update UI
        UpdateCleanBar();
        UpdateHungerBar();
        UpdateEnergyBar();
    }
    #region Reduce Needs
    private void ChangeHygiene()
    {
         _hygiene -= _hygieneTickRate * Time.deltaTime;
        if(_hygiene < 0 )
        {
            _hygiene = 0;
        }
    }
    private void ChangeHunger()
    {
        _hunger -= _hungerTickRate * Time.deltaTime;
        if(_hunger < 0 )
        {
            _hunger = 0;
        }
    }
    private void ChangeEnergy()
    {
        _energy -= _energyTickRate * Time.deltaTime;
        if(_energy < 0 )
        {
            _energy = 0;
        }
    }
    #endregion
    #region Reduce Needs Bar
    private void UpdateCleanBar()
    {
        float ratio = _hygiene / _max;
        CurrentHygiene.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HygieneText.text = (ratio * 100).ToString("0") + "%";
    }
    private void UpdateHungerBar()
    {
        float ratio = _hunger / _max;
        CurrentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        HungerText.text = (ratio * 100).ToString("0") + "%";
    }
    private void UpdateEnergyBar()
    {
        float ratio = _energy / _max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        EnergyText.text = (ratio * 100).ToString("0") + "%";
    }
    #endregion
    #region Satisfying Needs
    private void CleanTheChar()
    {
        Debug.Log("Clean clicked");
        _hygiene += 10;
        if(_hygiene > _max)
        {
            _hygiene = _max;
        }
        UpdateCleanBar();
    }
    private void FeedTheChar()
    {
         Debug.Log("Feed clicked");
        _hunger += 10;
        if(_hunger > _max)
        {
            _hunger = _max;
        }
        UpdateHungerBar();
    }
    private void PlayTheChar()
    {
         Debug.Log("Energy clicked");
        _energy += 10;
        if(_energy > _max)
        {
            _energy = _max;
        }
        UpdateEnergyBar();
    }
    #endregion
}
