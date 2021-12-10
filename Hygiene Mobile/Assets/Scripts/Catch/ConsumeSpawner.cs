using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeSpawner : MonoBehaviour
{
    public static ConsumeSpawner instance;
    private float speed = .1f;
    private float delayTime = 7f;
    public float DelayTime{ set { delayTime = value; } get { return delayTime; } }
    public float Speed{ set { speed = value; } get { return speed; } }
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;
    private List<float> remainingPositions = new List<float>();
    private int waveIndex;
    private float xPos = 0f;
    private int rand;
    private void Awake() {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    }
    void SpawnEnemy(float xPos){
        int r = Random.Range(0, 7);
        
        string enemyName = "";
        if(r == 0) enemyName = "Candy";
        else if(r == 1) enemyName = "Chocolate";
        else if(r == 2) enemyName = "Lollipop";
        else if(r == 3) enemyName = "Apple";
        else if(r == 4) enemyName = "Fish";
        else if(r == 5) enemyName = "Milk";
        else if(r == 6) enemyName = "Pechay";

         Debug.Log(xPos + " " + r + " " + enemyName);

        GameObject enemy = ObjectPooling.instance.GetPooledObject(enemyName);
        enemy.transform.position = new Vector3(xPos, transform.position.y, 0);
        enemy.SetActive(true);
    }
    void SelectWave(){
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);
        currentTime = delayTime;
        //currentTime = wave[waveIndex].delayTime;

        if(wave[waveIndex].spawnAmount == 1){
            xPos = Random.Range(-xLimit, xLimit);
        }else if(wave[waveIndex].spawnAmount > 1){
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }

        for(int i = 0; i < wave[waveIndex].spawnAmount; i++){
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerAnimationController.instance.StartMoving == true){
            currentTime -= Time.deltaTime;
            if(currentTime <= 0){
                SelectWave();
            }
        }
    }
}
[System.Serializable]
public class Wave{
    //public float delayTime;
    public float spawnAmount;
}