using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Canon : MonoBehaviour
{
    public GameObject Missile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Feux();
        }
    }


    void Feux()
    {
        var Missile = Instantiate(this.Missile, gameObject.transform.position, Quaternion.identity);
        Missile.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(20,26), Random.Range(20,26),0) *Random.Range(53.3f,54.5f), ForceMode.Force); //new Vector3(Random.Range(-3,3),0, Random.Range(-3,3))
    }
}
