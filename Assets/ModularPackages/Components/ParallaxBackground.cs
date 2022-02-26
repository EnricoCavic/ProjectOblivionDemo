using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    private Vector3 lastCamPosition;
    [SerializeField] private float parallaxValue;
    private float textureSize;

    private void Awake() 
    {
        Sprite sp = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sp.texture;
        lastCamPosition = camTransform.position; 
        textureSize = texture.width / sp.pixelsPerUnit * transform.lossyScale.x;

    }

    private void LateUpdate() 
    {
        Vector3 deltaMovement = camTransform.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxValue, 0, 0);
        lastCamPosition = camTransform.position; 

        if(camTransform.position.x - transform.position.x >= textureSize)
        {
            float offset = (camTransform.position.x - transform.position.x) % textureSize;
            transform.position = new Vector3(camTransform.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
