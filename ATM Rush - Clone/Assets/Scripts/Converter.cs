using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{

    public Mesh[] meshes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Parent")
        {

            for (int i = 0; i < Stack.Instance.collectedObjects.Count; i++)
            {

                Stack.Instance.collectedObjects[i].GetComponent<BoxCollider>().enabled = true;

            }

        }
        else if (other.tag == "Collectable")
        {


            switch (other.GetComponent<Collectable>().type.ToString())
            {

                case "Cash":

                    other.GetComponent<MeshFilter>().mesh = meshes[1];
                    other.GetComponent<MeshRenderer>().material  = Stack.Instance.materials[1];
                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Gold;
                    break;

                case "Gold":

                   
                    other.GetComponent<MeshFilter>().mesh = meshes[2];
                    other.GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Diamond;
                    break;

                case "Diamond":

                    //Stack.Instance.collectedObjects[i].GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                    break;


            }


           



        }

    }


}
