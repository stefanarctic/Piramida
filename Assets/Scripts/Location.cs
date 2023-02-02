using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public string locationName;
    public string information;
    public bool discovered;

    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !discovered)
        {
            discovered = true;
            Destroy(col);
            print($"Discovered location {locationName}");
            LocationsDiscovered.instance.DiscoverLocation(this);
            //ld.DiscoverLocation(this);
            //Location locationCopy = Instantiate(this);
            //LocationsDiscovered.instance.DiscoverLocation(locationCopy);
            //Destroy(locationCopy);
        }
    }

}
