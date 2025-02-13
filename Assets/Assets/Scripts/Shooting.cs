using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    private void Start()
    {
        
    }

    // Update is called once per frame      
    void Update()                           
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            print("HELLLLLLPPP");
        }

    }
    private void FixedUpdate()
    {

        LayerMask main = LayerMask.GetMask("Default");
        Vector3 mousepos = Input.mousePosition;
        Vector2 mouseDir = (Vector2)(mousepos - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir, main);
        

    }

}
