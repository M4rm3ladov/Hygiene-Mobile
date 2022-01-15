using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermManager : MonoBehaviour
{
    private List<Spawn> spawn = new List<Spawn>();
    public GameObject spawnPrefab;
    private float lastSpawn;
    private float deltaSpawn = 2f;

    // Start is called before the first frame update
    public Spawn GetSpawn(){
        Spawn g = spawn.Find(x => !x.IsActive);
        if(g == null){
            g = Instantiate(spawnPrefab).GetComponent<Spawn>();
            spawn.Add(g);
        }
        return g;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawn > deltaSpawn){
            Spawn g = GetSpawn();
            
            float randomX = Random.Range(-1.5f, 1.5f);
            g.LaunchGerms(Random.Range(-1.5f, 3f), randomX, -randomX);

            lastSpawn = Time.time;
        }
    }
}
