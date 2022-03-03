using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField]
   float lifetime;
   [SerializeField]
   float force;
   public int healthDamage = 1;
   public Rigidbody rigidBody;
   //Cinemachine.CinemachineImpulseSource source;

   private void Awake()
   {
      rigidBody = GetComponent<Rigidbody>();
      rigidBody.centerOfMass = transform.position;
   }

   //public void Fire()
   //{
   //   rigidBody.AddForce(transform.forward * (100 * Random.Range(1.3f, 1.7f)), ForceMode.Impulse);
   //   source = GetComponent<Cinemachine.CinemachineImpulseSource>();
   //   Vector3 velocity = Camera.main.transform.forward;
   //   source.GenerateImpulse(velocity);
   //}

   void OnCollisionEnter(Collision collision)
   {
      Debug.Log($"collision {collision.gameObject.name}");
      if (collision.gameObject.CompareTag(Tags.enemies.ToString()))
      {
         Debug.Log($"enemy");
         rigidBody.isKinematic = true;

         EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
         //enemyHealth.DepleteHealth(healthDamage);
         enemyHealth.GetKilled();
         StartCoroutine(Countdown());
      }
   }
   IEnumerator Countdown()
   {
      yield return new WaitForSeconds(lifetime);
      Destroy(gameObject);
   }
}

