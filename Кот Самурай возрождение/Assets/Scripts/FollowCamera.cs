using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject player; // Player
    private Vector3 offset;  

    void Start () 
    {        
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {        
        transform.position = player.transform.position + offset;
    }
}