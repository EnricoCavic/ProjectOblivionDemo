using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[CreateAssetMenu(fileName = "Extended Rule Tile", menuName = "2D/Tiles/Extended Rule Tile")]
public class ExtendedRuleTile : RuleTile 
{
 
    public string type;
    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;
       
        ExtendedRuleTile otherTile = other as ExtendedRuleTile;
       
        if (otherTile == null)
            return base.RuleMatch(neighbor, other);
 
        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
                // for(int mt = 0; mt < type.Length; mt++)
                // {
                //     for(int ot = 0; ot < type.Length; ot++)
                //     {
                //         if(type[mt] == otherTile.type[ot])
                //             return true;
                //     }
                // }

                return type == otherTile.type;
            case TilingRule.Neighbor.NotThis:
                return type != otherTile.type;
        }
        return true;
 
    }
}