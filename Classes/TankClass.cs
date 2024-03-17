using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankClass : BaseClass
{
    public GameObject barrierPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBarrier()
    {
        GameObject barrier = Instantiate(barrierPrefab);
        barrier.GetComponent<TankBarrier>().health = health / 2;
    }
}
