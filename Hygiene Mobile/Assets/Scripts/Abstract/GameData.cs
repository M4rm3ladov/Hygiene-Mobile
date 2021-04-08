using UnityEngine;
using GenericData;
 
[System.Serializable]
public class oneClass{
   
    public int integer1 = 1;
    public int integer2 = 2;
   
}
 
[System.Serializable]
public class twoClass{
   
    public float sencillo1 = 5f;
    public float sencillo2 = 6f;
   
}
 
[System.Serializable]
public class threeClass{
   
    public double doble1 = 10.123421234;
    public double doble2 = 11.123412342;
   
}
 
public class genericTest : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
       
        oneClass clas1 = new oneClass();
        twoClass clas2 = new twoClass();
        threeClass clas3 = new threeClass();
       
        Data.SavePDP(clas1,"clase1");
        Data.SavePDP(clas2,"clase2");
        Data.SavePDP(clas3,"clase3");
       
        oneClass c1 = (oneClass)Data.LoadPDP("clase1");
        twoClass c2 = (twoClass)Data.LoadPDP("clase2");
        threeClass c3 = (threeClass)Data.LoadPDP("clase3");
       
        Debug.Log(c1.integer1+" : "+c1.integer2);
        Debug.Log(c2.sencillo1+" : "+c2.sencillo2);
        Debug.Log(c3.doble1+" : "+c3.doble2);
       
    }  
   
}