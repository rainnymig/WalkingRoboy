using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGroundUnit : MonoBehaviour {

    public List<GameObject> PlantPrefabsFew;
    public List<GameObject> PlantPrefabsMany;
    private void Start()
    {
        Vector3 thisPosition = transform.position;
        float thisWidth = transform.localScale.x;
        float thisLength = transform.localScale.z;
        foreach (GameObject plant in PlantPrefabsFew)
        {
            int count = Random.Range(6, 10);
            for (int i = 1; i <= count; i++)
            {
                GameObject go = Instantiate(plant, this.transform, true);
                go.transform.position = thisPosition + new Vector3(Random.Range(-thisWidth / 2, thisWidth / 2), 0.25f,
                        Random.Range(-thisLength / 2, thisLength / 2));
            }
        }
        foreach (GameObject plant in PlantPrefabsMany)
        {
            int count = 2000;
            for (int i = 1; i <= count; i++)
            {
                GameObject go = Instantiate(plant, this.transform, true);
                go.transform.position = thisPosition + new Vector3(Random.Range(-thisWidth / 2, thisWidth / 2), 0.25f,
                        Random.Range(-thisLength / 2, thisLength / 2));
            }
        }
    }
}
