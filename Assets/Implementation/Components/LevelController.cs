using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class LevelController : MonoBehaviour
{
    GameObject targetVirtualCam;
    List<TilemapRenderer> tileLayers = new List<TilemapRenderer>();
    static GameObject currentVirtualCam;
    public Transform target;

    private void Awake() 
    {
        CasheComponents();
        UpdateNames();
    }


    private void Reset() 
    {
        CasheComponents();
        UpdateNames();
    }

    private void CasheComponents()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        foreach(Transform child in transform)
        {
            switch(child.tag)
            {
                case "VirtualCamera":
                    targetVirtualCam = child.gameObject;
                    CinemachineVirtualCamera vcam = targetVirtualCam.GetComponent<CinemachineVirtualCamera>();
                    if(vcam != null)
                    {
                        vcam.Follow = target;
                    }
                    break;
                
                case "TileMap":
                    tileLayers.Add(child.GetComponent<TilemapRenderer>());
                    break;
            }
        }
    }

    private void UpdateNames()
    {
        targetVirtualCam.name = "VCam " + name;

        for (int i = 0; i < tileLayers.Count; i++)
            tileLayers[i].name = "Tiles " + name + " " + tileLayers[i].sortingLayerName + tileLayers[i].sortingOrder;
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.gameObject.CompareTag("Player"))
            return;
            
        targetVirtualCam.gameObject.SetActive(true);

        if(currentVirtualCam != null)
            currentVirtualCam.gameObject.SetActive(false);

        currentVirtualCam = targetVirtualCam;        
    }
}
