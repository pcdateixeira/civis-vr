using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        GameObject gameObject =  GameObject.Find("Cube");
       gameObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102, 0.7f);
        CreateCoins(6);
    }

    private void CreateCoins(int coinsNum)
    {
        for (int i = 0; i < coinsNum; i++)
        {
            GameObject gameObject =  GameObject.Find("Cube");
            // GameObject CoinClone = Instantiate(coinOriginal);
            GameObject CoinClone = Instantiate(gameObject, new Vector3(gameObject.transform.position.x + i*10, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
            CoinClone.name = "CoinClone-" + (i + 1);
            //CoinClone.transform.parent = coinContainer.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
