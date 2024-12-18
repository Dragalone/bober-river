using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    private float speed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }

}
