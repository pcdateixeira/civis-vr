using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class DisplayChart : MonoBehaviour
{
    private DatabaseAccess databaseAccess;
    private TextMeshPro proposition;

    // Start is called before the first frame update
    void Start()
    {
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        proposition = GetComponentInChildren<TextMeshPro>();
        DisplayProposition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void DisplayProposition()
    {
        var task = databaseAccess.GetPropositionsFromDatabase();
        var result = await task;

        proposition.text = result[0];
    }
}
