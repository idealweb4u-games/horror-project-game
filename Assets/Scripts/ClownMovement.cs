using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class ClownMovement : MonoBehaviour
    {
        public Transform Player;
        public float MoveSpeed = 1.5f;
        int MaxDist = 10;
        int MinDist = 2;
/*
        void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player") && doorOpened)
            {
                if (!alreadyPlayed)
                {
                    controller.StopPlayer();
                    audio.Play();
                    alreadyPlayed = true;
                }

                Vector3 lookAt = Player.position;
                lookAt.y = transform.position.y;
                transform.LookAt(lookAt);

                // Move toward the player
                if (Vector3.Distance(transform.position, Player.position) >= MinDist)
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                    if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                    {
                        // Put your desired behavior here
                    }
                }
            }
        }
*/
        void Update()
        {
            if (ClownRoom.instance.chasePlayer == true)
            {
                Vector3 lookAt = Player.position;
                lookAt.y = transform.position.y;
                transform.LookAt(lookAt);

                if (Vector3.Distance(transform.position, Player.position) >= MinDist)
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                    if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                    {
                        // Put your desired behavior here
                    }
                }
            }
            
        }
    }
}
