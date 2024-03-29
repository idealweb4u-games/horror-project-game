using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AdvancedHorrorFPS
{
    public class PriestGrave : MonoBehaviour
    {
        [SerializeField] private GameObject priest;
        [SerializeField] private BoxScript body;

        void OnTriggerStay(Collider other)
        {
                Debug.Log("Follower has dewtedte");
            if (other.CompareTag("DeadBody") /*&& !body.isHolding*/) {
                Debug.Log("Follower has died");
                body.transform.position =transform.position;
                priest.transform.position= body.transform.position;
                priest.transform.GetComponent<EnemyMovement>().DeathAnimation();
                priest.transform.GetComponent<EnemyMovement>().enabled = false;
                UIManager.Instance.EndingCameraCutScene();





            }
        }
    }
}
