using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast2DManager : MonoBehaviour
{
 
    public List<BoxCast2DCollision> castList = new List<BoxCast2DCollision>();
    
    public BoxCast2DCollision GetCast(string _id)
    {
        foreach (BoxCast2DCollision _cast in castList) 
            if(_cast.id == _id)
                return _cast;
                  
        return null;
    }    

    public bool CheckCast(string _id)
    {
        return (bool)GetCast(_id).CheckOverlap();
    }

    private void OnDrawGizmos() 
    {
        foreach (BoxCast2DCollision _cast in castList)
        {   
            if(_cast.toggleDraw && _cast.origin != null)
                _cast.DrawCollision();
        }           

    }

}
