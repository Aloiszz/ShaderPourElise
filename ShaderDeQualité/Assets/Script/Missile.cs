using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : MonoBehaviour
{
    public GameObject Bomb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var missile = Instantiate(Bomb, gameObject.transform.position, quaternion.identity); //new Vector3(Random.Range(-3,3),0, Random.Range(-3,3))
            Destroy(missile,.6f); 
            CinemachineShake.instance.ShakeCamera(2,2,0.5f);
        }
        
    }
}
