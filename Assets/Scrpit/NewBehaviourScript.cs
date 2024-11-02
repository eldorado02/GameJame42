// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;
public class MouvementGaucheDroite : MonoBehaviour
{
    public float vitesse = 3f;
    public float amplitude = 5f;
    private Vector3 positionInitiale;
    void Start()
    {
        positionInitiale = transform.position;
    }
    void Update()
    {
        float mouvementX = Mathf.Sin(Time.time * vitesse) * amplitude;
        transform.position = new Vector3(positionInitiale.x + mouvementX, positionInitiale.y, positionInitiale.z);
    }
}