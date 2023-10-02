using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubcriber : MonoBehaviour
{
    [SerializeField] AudioVisualizerManager visualizerManager;
    [SerializeField] GameObject nail;
    [SerializeField] GameObject movingBeam;
    private void OnEnable()
    {
        visualizerManager.OnPeakReachedAction += Handler;
    }

    private void OnDisable()
    {
        visualizerManager.OnPeakReachedAction -= Handler;
    }

    private void Handler()
    {
        //gameObject.GetComponent<Animator>().Play("SpearJump");
        var newNail = Instantiate(nail, new Vector2(-9.19f, -2.2f), Quaternion.identity);
        newNail.transform.parent = movingBeam.transform;
    }
}
