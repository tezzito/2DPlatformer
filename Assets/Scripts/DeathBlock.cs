using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    [SerializeField] private float maxY = 0;
    [SerializeField] private float minY = 0;
    [SerializeField] private float speed = 1;
    public bool goUp = true;


    private void Start()
    {
        maxY += transform.position.y;
        minY -= transform.position.y;
    }

    void Update()
    {
        if (goUp)
        {
            if (maxY > transform.position.y)transform.Translate(Vector3.up * speed * Time.deltaTime);
            
            else goUp = false;
            
        }
        if (!goUp)
        {
            if (minY < transform.position.y) transform.Translate(Vector3.up * -speed * Time.deltaTime);
            
            else goUp = true;
        }
    }
}
