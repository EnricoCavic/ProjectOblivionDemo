using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastManager : MonoBehaviour
{
    public List<BoxCastCollision> castList = new List<BoxCastCollision>();

    public bool CheckCast(string _id)
    {
        foreach (BoxCastCollision _cast in castList)
        {   
            if(_cast.id == _id)
                return _cast.CheckOverlap();

        }           

        return false;
    }

    private void OnDrawGizmos() 
    {
        foreach (BoxCastCollision _cast in castList)
        {   
            if(_cast.toggleDraw && _cast.origin != null)
                _cast.DrawCollision();
        }           

    }

}
