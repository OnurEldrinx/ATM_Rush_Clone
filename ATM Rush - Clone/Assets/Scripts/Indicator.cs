using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Indicator : MonoBehaviour
{

    public GameObject cash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGameOver)
        {

            cash.transform.DOScaleY(ATM.counter * 0.25f, 5);

        }

    }
}
