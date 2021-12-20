using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public List<Transform> droppedItems;

    float colSize;
    // Start is called before the first frame update
    void Start()
    {

        droppedItems = new List<Transform>();

        colSize = GameObject.Find("Stack Parent").GetComponent<BoxCollider>().size.z;

    }

    // Update is called once per frame
    void Update()
    {

        

    }


    public void DroppedItems()
    {

        

        for(int i = 0; i < droppedItems.Count; i++)
        {

            Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f), GameObject.Find("Collector").transform.position.y, Random.Range(GameObject.Find("Collector").transform.position.z + 1, GameObject.Find("Collector").transform.position.z + 3));


            droppedItems[i].transform.gameObject.SetActive(true);
            droppedItems[i].transform.localPosition = randomPosition;
            


        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Parent")
        {


            for (int i=0;i< Stack.Instance.collectedObjects.Count;i++)
            {

                Stack.Instance.collectedObjects[i].GetComponent<BoxCollider>().enabled = true;

            }


        }else if (other.tag == "Collectable"){


            
                
                int index = Stack.Instance.collectedObjects.IndexOf(other.transform);

            Debug.Log(index);

                for (int i=index;i<Stack.Instance.collectedObjects.Count;i++)
                {


                    Stack.Instance.collectedObjects[i].gameObject.SetActive(false);
                    

                    if (index - 1 >= 0)
                    {
                        Stack.Instance.Previous = Stack.Instance.collectedObjects[index - 1];
                    }
                    else
                    {

                        Stack.Instance.Previous = GameObject.Find("Collector").transform;

                    }

                if (Stack.Instance.ParentCollider.size.z > colSize)
                {

                    Stack.Instance.ParentCollider.size -= new Vector3(0, 0, other.transform.localScale.z);
                    Stack.Instance.ParentCollider.center -= new Vector3(0, 0, other.transform.localScale.z / 2);

                }

                    


            }



                
            }
            


        

    }

    





}
