using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalexBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float paralexEffect;
    private float xPosition;
    private float length;
    private void Awake()
    {
        cam=GameObject.Find("Main Camera");
        length=GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Start is called before the first frame update
    void Start()
    {
        xPosition=transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x*(1-paralexEffect);
        float distanceToMove = cam.transform.position.x*paralexEffect;

        transform.position=new Vector3(xPosition+distance, transform.position.y);
        
        if(distanceToMove>xPosition + length)
            xPosition=xPosition+length;
        else if(distanceToMove<xPosition-length)
            xPosition=xPosition-length;
    }
}
