using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Finish : MonoBehaviour
{

    [SerializeField] private GameObject materialHolder;

    private float speed = 0.1f;
    private new Renderer renderer;
    private float offset;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {

        renderer = materialHolder.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.isGameOver)
        {

            MaterialOffset();

        }

        score = ATM.counter;

    }

    public void MaterialOffset()
    {

        offset = speed * Time.time;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Parent")
        {



            for (int i = 0; i < Stack.Instance.collectedObjects.Count; i++)
            {

                Stack.Instance.collectedObjects[i].GetComponent<BoxCollider>().enabled = true;

            }

            Stack.Instance.ParentCollider.enabled = false;



        }
        else if (other.tag == "Collectable")
        {

            other.GetComponent<BoxCollider>().enabled = false;

            other.transform.parent = GameObject.Find("Finish Parent").transform;

            other.transform.DOLocalMoveZ(0,0.1f);

            other.transform.DOLocalMoveX(-18, 3);


            Stack.Instance.collectedObjects.Remove(other.transform);

            ATM.counter += ((int)other.GetComponent<Collectable>().type);

            Destroy(other.gameObject, 3);

            
        }
        else if (other.tag == "Collector")
        {

            GameManager.Instance.isGameOver = true;


        }

    }

    



}
