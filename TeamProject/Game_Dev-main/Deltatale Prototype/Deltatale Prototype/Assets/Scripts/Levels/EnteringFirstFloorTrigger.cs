using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringFirstFloorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      SceneLoader.Load(SceneLoader.Scene.FirstFloor);
    }
}
