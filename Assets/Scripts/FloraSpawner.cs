using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraSpawner : MonoBehaviour
{
    public GameObject floraOriginal;


    public int floraCount = 10;

    public int range = 10;
    
    public float heigh = 0;

    public int minimunDistance = 14;

    private Vector3[] floras;

    private void Awake()
    {
	floraOriginal.tag = "Ground";
        floras = new Vector3[floraCount];
        int i = 0;
        while (i < floraCount)
        {
            Vector3 v = generatePositionVector();
            if (availableSpace(v))
            {
                Quaternion basefloraRotation = floraOriginal.transform.rotation;
                var floraGameObject = Instantiate(floraOriginal, v, basefloraRotation);
                i++;
            } 
        }
    }

    private bool availableSpace(Vector3 vector)
    {
        for(int i = 0; i < floras.Length;  i++)
        {
            if(Vector3.Distance(floras[i], vector) < minimunDistance)
            {
                return false;
            }
        }
        return true;
    }

    private Vector3 generatePositionVector()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        return new Vector3(transform.position.x + x, heigh, transform.position.z + z);
    }

}
