using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static TextMesh scoreText;

    // Start is called before the first frame update
    void Start()
    {

        scoreText = GetComponent<TextMesh>();

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = ATM.counter.ToString();

    }
}
