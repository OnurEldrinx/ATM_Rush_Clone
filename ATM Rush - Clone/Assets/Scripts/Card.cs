using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{

    

    private void Start()
    {

        transform.DOMoveX(3, 1.5f);

    }


    private void Update()
    {


        if (transform.position.x == -3)
        {

            transform.DOMoveX(3, 1.5f);


        }

        if (transform.position.x == 3)
        {

            transform.DOMoveX(-3,1.5f);

        }




    }



}
