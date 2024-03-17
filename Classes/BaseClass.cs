using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    /*
     * Baseclass da nogle af tingene er ens for klasserne
     */

    public string className;
    public float health;
    public float[] damage;
    public float[] coords;

    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //kode der flytter entity
    public void Move()
    {

    }

    //erstat temp med rigtige senere?
    public void BaseSpawn(float tempHealth, float[] tempDamage, float[] tempCoords)
    {
        health = tempHealth;
        damage = tempDamage;
        coords = tempCoords;

    }
}
