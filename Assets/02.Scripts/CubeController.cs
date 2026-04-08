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
        SequenceAnim();
    }

    private void MoveCube()
    {
        myTween = cube.transform.DOMoveX(5f, 2f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.OutSine);
    }

    private void SequenceAnim()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(cube.transform.DOMoveX(10, 3f))
            .Join(cube.transform.DOScale(new Vector3(5, 5, 5), 10f))
            .Join(cube.GetComponent<Renderer>().material.DOColor(Color.green, 5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InputFunc()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
