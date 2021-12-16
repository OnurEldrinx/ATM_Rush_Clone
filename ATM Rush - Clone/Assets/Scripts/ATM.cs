using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ATM : MonoBehaviour
{

    public TextMesh counterText;
    public static int counter = 0;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        counterText.text = counter.ToString();

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



            if (Stack.Instance.collectedObjects.Contains(other.transform))
            {

                int index = Stack.Instance.collectedObjects.IndexOf(other.transform);

                for (int i = index; i < Stack.Instance.collectedObjects.Count; i++)
                {


                    counter += ((int)Stack.Instance.collectedObjects[i].GetComponent<Collectable>().type);

                    Stack.Instance.collectedObjects[i].gameObject.SetActive(false);
                    Stack.Instance.collectedObjects.RemoveAt(i);

                    Stack.Instance.ParentCollider.size -= new Vector3(0, 0, other.transform.localScale.z);
                    Stack.Instance.ParentCollider.center -= new Vector3(0, 0, other.transform.localScale.z / 2);

                }

                if (index - 1 >= 0)
                {
                    Stack.Instance.Previous = Stack.Instance.collectedObjects[index - 1];
                }
                else
                {

                    Stack.Instance.Previous = GameObject.Find("Collector").transform;

                }
            }



        }

    }

}
