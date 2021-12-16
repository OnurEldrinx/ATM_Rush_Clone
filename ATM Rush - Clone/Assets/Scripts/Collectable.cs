using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public bool isCollected;
    public static int price;
    public CollectableTypes type;

    public enum CollectableTypes
    {

        Cash = 5,
        Gold = 10,
        Diamond = 15


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
