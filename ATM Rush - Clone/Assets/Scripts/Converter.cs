using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
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

                    other.GetComponent<MeshRenderer>().material = Stack.Instance.materials[1];
                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Gold;
                    break;

                case "Gold":

                    other.GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Diamond;
                    break;

                case "Diamond":

                    //Stack.Instance.collectedObjects[i].GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                    break;


            }


            /*if (Stack.Instance.collectedObjects.Contains(other.transform))
            {

                int index = Stack.Instance.collectedObjects.IndexOf(other.transform);

                for (int i = index; i < Stack.Instance.collectedObjects.Count; i++)
                {

                    switch (Stack.Instance.collectedObjects[i].GetComponent<Collectable>().type.ToString())
                    {

                        case "Cash":

                            Stack.Instance.collectedObjects[i].GetComponent<MeshRenderer>().material = Stack.Instance.materials[1];
                            Stack.Instance.collectedObjects[i].GetComponent<Collectable>().type = Collectable.CollectableTypes.Gold;
                            break;

                        case "Gold":

                            Stack.Instance.collectedObjects[i].GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                            Stack.Instance.collectedObjects[i].GetComponent<Collectable>().type = Collectable.CollectableTypes.Diamond;
                            break;

                        case "Diamond":

                            //Stack.Instance.collectedObjects[i].GetComponent<MeshRenderer>().material = Stack.Instance.materials[2];
                            break;


                    }


                }

                if (index - 1 >= 0)
                {
                    Stack.Instance.Previous = Stack.Instance.collectedObjects[index - 1];
                }
                else
                {

                    Stack.Instance.Previous = GameObject.Find("Collector").transform;

                }
            }*/



        }

    }


}
