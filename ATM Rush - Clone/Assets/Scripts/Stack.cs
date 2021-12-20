using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{

    public static Stack Instance;

    public Material[] materials;

    [SerializeField] private Transform previous;
    [SerializeField] private Transform parent;
    private BoxCollider parentCollider;

    public List<Transform> collectedObjects;
    public List<Transform> activeObjects;

    public Transform Parent { get => parent; set => parent = value; }
    public BoxCollider ParentCollider { get => parentCollider; set => parentCollider = value; }
    public Transform Previous { get => previous; set => previous = value; }

    private void Awake()
    {

        DOTween.SetTweensCapacity(1250, 50);

        if (Instance == null)
        {

            Instance = this;

        }



    }

    // Start is called before the first frame update
    void Start()
    {

        collectedObjects = new List<Transform>();
        activeObjects = new List<Transform>();
        parentCollider = parent.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (collectedObjects.Count > 0)
        {

            WavyMovement();


        }

        for(int i = 0; i < collectedObjects.Count; i++)
        {

            if (!collectedObjects[i].gameObject.activeSelf)
            {

                collectedObjects.RemoveAt(i);
            }

        }

    }

    public void WavyMovement()
    {

        for (int i = collectedObjects.Count-1;i>=0;i--)
        {


            if (i == 0)
            {

                collectedObjects[i].DOMoveX(GameObject.Find("Collector").transform.position.x, 0.1f);

            }
            else
            {

                collectedObjects[i].DOMoveX(collectedObjects[i - 1].transform.position.x, 0.1f);

            }


        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Collectable")
        {

            Transform jumper = other.transform;

            jumper.DOShakeScale(0.5f,Vector3.up * 2f,20,50,true).SetEase(Ease.InOutSine);

            other.GetComponent<Collider>().enabled = false;

            other.transform.position = previous.transform.position;
            other.transform.parent = parent;

            other.transform.localPosition += new Vector3(0,0,previous.localScale.z);
            previous = other.transform;

            parentCollider.size += new Vector3(0,0,other.transform.localScale.z);
            parentCollider.center += new Vector3(0, 0, other.transform.localScale.z/2);

            other.GetComponent<Collectable>().isCollected = true;

            collectedObjects.Add(other.transform);

            

            switch (other.GetComponent<MeshRenderer>().sharedMaterial.name)
            {

                case "Money":

                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Cash;
                    break;

                case "Gold":

                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Gold;
                    break;

                case "Diamond":

                    other.GetComponent<Collectable>().type = Collectable.CollectableTypes.Diamond;
                    break;


            }

        }

    }

}
