using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSClass : BaseClass
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(float tempHealth, float[] tempDamage, float[] tempCoords)
    {

        BaseSpawn(tempHealth, tempDamage, tempCoords);
    }
}
