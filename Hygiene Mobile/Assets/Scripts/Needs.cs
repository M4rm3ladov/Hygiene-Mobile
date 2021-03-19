using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Needs : MonoBehaviour
{
    [SerializeField] 
    private Image CurrentHygiene;
    [SerializeField]
    private Image CurrentHunger;
    [SerializeField]
    private Image CurrentEnergy;

    [SerializeField]
    public Text HygieneText;
    [SerializeField]
    public Text HungerText;
    [SerializeField]
    public Text EnergyText;

    private float _hygiene = 100;
    private float _hunger = 100;
    private float _energy = 100;
    private float _max = 100;

    [SerializeField]
    private Button Feed;
    [SerializeField]
    private Button Hygiene;
    [SerializeField]
    private Button Play;
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
        _hygiene -= 5.5f * Time.deltaTime;
        if(_hygiene < 0 )
        {
            _hygiene = 0;
        }
        _hunger -= 6f * Time.deltaTime;
        if(_hunger < 0 )
        {
            _hunger = 0;
        }
        _energy -= 5.75f * Time.deltaTime;
        if(_energy < 0 )
        {
            _energy = 0;
        }

        UpdateCleanBar();
        UpdateHungerBar();
        UpdateEnergyBar();
    }
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
}
