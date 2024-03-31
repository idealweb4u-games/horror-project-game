using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AdvancedHorrorFPS
{
    public class LevelEnding : MonoBehaviour
    {
        [SerializeField] private GameObject Enemy;
        [SerializeField] private BoxScript collectable;
        public GameObject ExtraItems;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Collectable") ) {
                Debug.Log("Follower has died");
                collectable.transform.position = transform.position;
                if(ExtraItems != null) {ExtraItems.SetActive(true);}
                Enemy.transform.position= collectable.transform.position;
                Enemy.transform.GetComponent<EnemyMovement>().DeathAnimation();
                Enemy.transform.GetComponent<EnemyMovement>().enabled = false;
                Enemy.transform.GetComponent<NavMeshAgent>().enabled = false;
                UIManager.Instance.EndingCameraCutScene();
            }
        }
    }
}
