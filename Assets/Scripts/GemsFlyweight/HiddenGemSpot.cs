using UnityEngine;

public class HiddenGemSpot : MonoBehaviour
{
    public GameObject gemPrefab;
    public Sprite gemSprite;
    public AudioClip gemSound;
    public int gemValue = 10;
    public Camera mainCamera;

    private bool found = false;
    private GemsFactoryFlyweight factory;

    void Awake()
    {
        factory = new GemsFactoryFlyweight();
    }

    void Update()
    {
        if (found) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK detectado");

            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            //RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            Collider2D hit = Physics2D.OverlapPoint(worldPos);


            if (hit== null)
            {
                Debug.Log("Overlap NO detectó nada");
            }
            else
            {
                Debug.Log("Overlap golpeó: " + hit.name);
            }


            if (hit != null && hit.gameObject == gameObject)
            {
                RevealGem();
            }
        }
    }

    void RevealGem()
    {
        found = true;
        Debug.Log("GEMA ENCONTRADA");


        GameObject gemObj = Instantiate(gemPrefab, transform.position, Quaternion.identity);
        Gems gem = gemObj.GetComponent<Gems>();

        GemsFlyweight flyweight = factory.GetFlyweight(
            GemType.Green,
            gemSprite,
            gemSound,
            gemValue
        );

        gem.Initialize(flyweight);

        GemsCounter.Instance.AddGem(flyweight.value);

        if (flyweight.pickupSound != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = flyweight.pickupSound;
            audioSource.Play();
        }

        // Se recoge inmediatamente
        Destroy(gemObj,2.0f);
    }
}

