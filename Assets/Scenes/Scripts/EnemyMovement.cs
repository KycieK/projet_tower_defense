using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[RequireComponent(typeof(Enemy))]
public class enemyMovement : MonoBehaviour
{
    private Transform target; 
    private int wavepointIndex = 0;
    private Enemy enemy;
    private float trueSpeed;

    void Start ()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

     void Update ()
     {
          Vector3 dir = target.position - transform.position; 
          trueSpeed = enemy.speed * WorldTime.getActionSpeed();
          transform.Translate(dir.normalized * trueSpeed * Time.deltaTime, Space.World);

          if (Vector3.Distance(transform.position, target.position) <= 0.5f) //plus la valeure xf est grande plus on a un chemin approximatif
          {
               GetNextWaypoint();
          }

          enemy.speed = enemy.startSpeed; 
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
          PlayerStats.Lives -= enemy.damage;
          Destroy(gameObject);

          if(PlayerStats.Lives <= 0) 
          {
               UtilityUI.EndGame();
               return;
          }
     }

}
