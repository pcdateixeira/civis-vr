using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeMover : MonoBehaviour
{

    public float multiplier = 1;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.localPosition;
        pos.y = Mathf.Sin(Time.timeSinceLevelLoad) * multiplier;
        this.transform.localPosition = pos;
        
        text.text = Time.timeSinceLevelLoad.ToString();
    }
}
