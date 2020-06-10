using UnityEngine;
using UnityEngine.UI;

public class ShapeAnimation : MonoBehaviour
{

    float rotateSpeed;
    float moveSpeed;
    float x = 1;
   
    void Start()
    {
        Destroy(this.gameObject, 60);
        Image theImage = GetComponent<Image>();
        theImage.color = new Color(255, 255, 255, Random.Range(.03f, .25f));
        rotateSpeed = Random.Range(1, 5);
        moveSpeed = Random.Range(50, 100);
        x = Random.Range(.3f, 1);
        transform.localScale = new Vector3(x, x, x);
        
    }

    
    void Update()
    {
        Vector3 yPos = transform.localPosition;
        yPos = new Vector3(yPos.x, yPos.y - moveSpeed * Time.deltaTime, yPos.z);
        transform.localPosition = yPos;

        x += 1;
        transform.localRotation = Quaternion.Euler(0, 0, x);
    }
}
