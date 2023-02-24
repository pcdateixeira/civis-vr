using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePloter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject original = GameObject.Find("Plane");
    public GameObject coinContainer;

    void Start()
    {
        /*
        var color =  new Color(0,0,0, 0.2f);
        original.GetComponent<Renderer>().material.color = color;

        for (int i = 0; i < 7; i++)
        {
            // GameObject CoinClone = Instantiate(original);
            GameObject CoinClone = Instantiate(original, new Vector3(original.transform.position.x + (i+1)*0.1f, original.transform.position.y, original.transform.position.z), original.transform.rotation);
            CoinClone.name = "Plane-" + (i + 1);
            CoinClone.transform.parent = coinContainer.transform;
            CoinClone.GetComponent<Renderer>().material.color = color;
        }
        */
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
