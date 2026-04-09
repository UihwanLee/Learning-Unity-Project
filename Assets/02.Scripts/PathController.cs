using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public Transform player;
    public PathType pathController = PathType.CatmullRom;

    public Vector3[] pathVal = new Vector3[3];
    public Tween myTween;

    // Start is called before the first frame update
    void Start()
    {
        myTween = player.transform.DOPath(pathVal, 5, pathController);
        myTween.SetEase(Ease.Linear).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
