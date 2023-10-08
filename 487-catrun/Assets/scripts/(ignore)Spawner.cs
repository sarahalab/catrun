using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dudePrefabVar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(dudePrefabVar);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
