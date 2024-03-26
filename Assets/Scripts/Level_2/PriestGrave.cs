using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdvancedHorrorFPS
{
    public class PriestGrave : MonoBehaviour
    {
        [SerializeField] private GameObject priest;
        [SerializeField] private BoxScript body;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Collectable") && !body.isHolding)
            {
                Debug.Log("Follower has died");
                priest.transform.position= body.transform.position;
                UIManager.Instance.fire.transform.position= body.transform.position;
                UIManager.Instance.fire.Play();
                UIManager.Instance.fire.gameObject.SetActive(true);
                UIManager.Instance.audioSource.clip = UIManager.Instance.audioManager.Audio_DemonKilling[2];
                UIManager.Instance.audioSource.Play();

            }
        }
    }
}
