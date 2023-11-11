using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float speed = 10f;
     public int damage = 1;

     private Transform target; 
     private int wavepointIndex = 0;


     void Start ()
     {
          target = Waypoints.points[0];
     }

     void Update ()
     {
          Vector3 dir = target.position - transform.position; 
          transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

          if (Vector3.Distance(transform.position, target.position) <= 0.2f)
          {
               GetNextWaypoint();
          }
     }

     void GetNextWaypoint()
     {
          if(wavepointIndex >= Waypoints.points.Length - 1)
          {
               EndPath();
               return;
          }

          wavepointIndex++; 
          target = Waypoints.points[wavepointIndex];
     }

     void EndPath()
     {
          PlayerStats.Lives -= damage;
          Destroy(gameObject);

          if(PlayerStats.Lives <= 0) 
          {
               GameManager.EndGame();
               return;
          }
     }
}
