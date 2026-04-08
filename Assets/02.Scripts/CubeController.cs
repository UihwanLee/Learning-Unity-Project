using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject cube;
    Tween myTween;

    // Start is called before the first frame update
    void Start()
    {
        myTween = cube.transform.DOMoveX(5f, 2f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.OutSine);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myTween.Pause();
            Debug.Log("Paused");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myTween.Play();
            Debug.Log("Played");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myTween.Kill();
            Debug.Log("Destoryed");
        }
    }
}
