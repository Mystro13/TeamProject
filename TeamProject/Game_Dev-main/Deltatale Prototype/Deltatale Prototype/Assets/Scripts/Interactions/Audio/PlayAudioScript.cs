using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioScript : MonoBehaviour
{
   public AudioSource audioSource;
   public void Execute()
   {
      audioSource.Play();
   }
}
