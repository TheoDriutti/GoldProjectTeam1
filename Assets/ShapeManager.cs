using System.Collections;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{

    public GameObject[] theShapes;
    private Transform instantiateTransform;
    public float timeBtwSpawn;
    public GameObject theCanvas;

    private Vector3 sVector;
    private Vector3 save;

    void Start()
    {
        instantiateTransform = GameObject.FindGameObjectWithTag("Instantiate").GetComponent<Transform>();
        save = instantiateTransform.transform.position;
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        /*Vector3 sVector = theCanvas.transform.position;
        sVector.x = sVector.x + Random.Range(-550, 550);
        Debug.Log(sVector.x);
        sVector.y = 0;*/
        instantiateTransform.transform.position = save;
        //save = instantiateTransform.transform.position;
        //instantiateTransform.transform.position = new Vector3(0, 1080, 0);
        //save = instantiateTransform.transform.position;
        sVector = instantiateTransform.transform.position;
        sVector.x = sVector.x + Random.Range(-2.3f, 2.3f);
        //Debug.Log(sVector);
        instantiateTransform.transform.position = sVector;
        //Debug.Log(instantiateTransform.transform.position);
        GameObject shape = Instantiate(theShapes[Random.Range(0, theShapes.Length)], instantiateTransform.transform.position, Quaternion.identity) as GameObject;
        shape.transform.SetParent(theCanvas.transform);
        yield return new WaitForSeconds(timeBtwSpawn);
        StartCoroutine(Spawning());
    }

}
