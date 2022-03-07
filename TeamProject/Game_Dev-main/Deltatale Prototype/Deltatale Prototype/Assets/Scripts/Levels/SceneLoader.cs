using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
   public enum Scene
   {
      Cemetery,
      FirstFloor
   }

   public static void Load(Scene scene)
   {
      SceneManager.LoadScene(scene.ToString());
   }
}
