using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalOriginal;

    public int animalCount = 10;

    public int range = 10;
    
    public float heigh = 0;

    public int minimunDistance = 14;

    private Vector3[] animals;

    private void Awake()
    {
        animals = new Vector3[animalCount];
        int i = 0;
        while (i < animalCount)
        {
            Vector3 v = generatePositionVector();
            if (availableSpace(v))
            {
                Quaternion baseAnimalRotation = animalOriginal.transform.rotation;
                var animalGameObject = Instantiate(animalOriginal, v, baseAnimalRotation);
                i++;
            } 
        }
    }

    private bool availableSpace(Vector3 vector)
    {
        for(int i = 0; i < animals.Length;  i++)
        {
            if(Vector3.Distance(animals[i], vector) < minimunDistance)
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
