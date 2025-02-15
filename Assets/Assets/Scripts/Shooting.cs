using UnityEngine;

public class Shooting : MonoBehaviour
{
    Rigidbody rb;
    float speed;
    private void Start()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame      
    void Update()                           
    {


    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);
        LayerMask main = LayerMask.GetMask("Default");
        Vector3 mousepos = Input.mousePosition;
        Vector2 mouseDir = (Vector2)(mousepos - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir, main);
        Debug.DrawLine(transform.position, mouseDir, Color.red, 1);
        if (hit)
        {
            if (hit.transform.name.Equals("Square"))
            {
                Debug.Log("Hit square cheers");
            }
        }

    }

}
