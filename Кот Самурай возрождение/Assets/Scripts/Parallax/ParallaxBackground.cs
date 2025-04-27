using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform playerTransform;
    public float parallaxFactor;

    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (playerTransform == null)
            playerTransform = GameObject.FindWithTag("Player").transform;

        lastPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        float deltaX = playerTransform.position.x - lastPlayerPosition.x;
        float deltaY = playerTransform.position.y - lastPlayerPosition.y;

        transform.position += new Vector3(deltaX * parallaxFactor, deltaY * parallaxFactor, 0);
        lastPlayerPosition = playerTransform.position;
    }
}