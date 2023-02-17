using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlotter : MonoBehaviour
{

    public CubeMover cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CubeMover cube = GameObject.Instantiate(cubePrefab);
        cube.multiplier = 3;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
