using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsDiscovered : MonoBehaviour
{

    private static LocationsDiscovered Instance = null;
    public static LocationsDiscovered instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType<LocationsDiscovered>();
            return Instance;
        }
    }

    public List<Location> locations;

    private void Start()
    {
        locations = new List<Location>();
    }

    public void DiscoverLocation(Location _location)
    {
        locations.Add(_location);
        print($"Added {_location.locationName} to the locations list");
    }

}
