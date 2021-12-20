using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hand : MonoBehaviour
{

    private void Start()
    {

        transform.DOMoveX(5, 1.5f);

    }


    private void Update()
    {


        if (transform.position.x == 5)
        {

            transform.DOMoveX(10, 1.5f);


        }

        if (transform.position.x == 10)
        {

            transform.DOMoveX(5, 1.5f);

        }




    }

}
