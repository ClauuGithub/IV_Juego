using UnityEngine;
[System.Serializable]

public class GemsFlyweight
{
    public Sprite sprite;
    public AudioClip pickupSound;
    public int value;

    public GemsFlyweight(Sprite sprite, AudioClip pickupSound,int value) {

        this.sprite = sprite;
        this.pickupSound = pickupSound;
        this.value = value;
    }
    
}
