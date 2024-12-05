using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateParticle : MonoBehaviour
{
    public GameObject particle;
    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 screenCoords = Input.mousePosition;
        //    screenCoords.z = 10;
        //    Vector3 gamCoords = _cam.ScreenToWorldPoint(screenCoords);
        //    Instantiate(particle, gamCoords, Quaternion.identity);
        //}

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Vector3 screenCoord = touch.position;
                screenCoord.z = 10;
                Vector3 gameCoord = _cam.ScreenToWorldPoint(screenCoord);
                Instantiate(particle, gameCoord, Quaternion.identity);
            }
        }
    }
}
