using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessingWithArrays : MonoBehaviour
{

    //[SerializeField] 
    public string[] myStringArray;
    public GameObject[] objectArray;
    public int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myStringArray[x]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
