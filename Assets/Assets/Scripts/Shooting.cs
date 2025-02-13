using UnityEngine;

public class Shooting : MonoBehaviour
{

    float speed = 10;
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
    }
    Vector2 moveDirecion;

    Vector3 mousePosition;
    
    // Update is called once per frame      
    void Update()                           
    {                                       
        mousePosition = Input.mousePosition;
    }
    private void FixedUpdate()
    {
        Debug.DrawLine(transform.position, mousePosition, Color.red);
    }

}
