using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverCollision : Singleton<GameOverCollision>
{
    public UnityEvent onGameOver=new UnityEvent();
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            Time.timeScale = 0;
            Debug.Log("game Over Now");
            onGameOver?.Invoke();
        }
    }
}
