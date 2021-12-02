using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;
    private List<float> remainingPositions = new List<float>();
    private int waveIndex;
    private float xPos = 0f;
    private int rand;
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    }
    void SpawnEnemy(float xPos){
        int r = Random.Range(0, 3);
        GameObject enemyObj = Instantiate(enemyPrefabs[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }
    void SelectWave(){
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;

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
    public float delayTime;
    public float spawnAmount;
}