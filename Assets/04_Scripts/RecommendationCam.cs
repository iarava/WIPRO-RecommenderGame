using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecommendationCam : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera Vcam;

    private bool test = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            test = !test;

        if (test)
            Vcam.Priority = 2;
        else
            Vcam.Priority = 0;
    }
}
