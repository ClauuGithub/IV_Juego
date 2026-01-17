using UnityEngine;
using System.Collections.Generic;

public enum GemType
{
    Green
}

public class GemsFactoryFlyweight
{
    private Dictionary<GemType, GemsFlyweight> flyweights = new Dictionary<GemType, GemsFlyweight>();

    public GemsFlyweight GetFlyweight( GemType type, Sprite sprite, AudioClip sound, int value)
     {
            if(!flyweights.ContainsKey(type))
            {
                flyweights[type] = new GemsFlyweight(sprite, sound, value);
            }
            return flyweights[type];
     }


}
