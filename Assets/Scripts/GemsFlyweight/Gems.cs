using UnityEngine;

public class Gems : MonoBehaviour
{
    private GemsFlyweight flyweight;

    public void Initialize(GemsFlyweight flyweight)
    {
        this.flyweight = flyweight;
        GetComponent<SpriteRenderer>().sprite = flyweight.sprite;

        if (flyweight.pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(
                flyweight.pickupSound,
                transform.position
            );
        }
    }
}

