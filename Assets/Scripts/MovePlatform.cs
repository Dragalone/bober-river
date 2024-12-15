using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    [SerializeField] private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
    }

}
