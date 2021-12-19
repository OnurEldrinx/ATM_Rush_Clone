using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject focus;
    public GameObject finishCam;
    public GameObject mainCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGameOver)
        {

            mainCam.SetActive(false);

            finishCam.gameObject.SetActive(true);

            finishCam.transform.position = new Vector3(finishCam.transform.position.x,focus.transform.position.y, finishCam.transform.position.z);



        }

    }
}
