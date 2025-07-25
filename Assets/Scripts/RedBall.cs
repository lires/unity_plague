using UnityEngine;

public class RedBall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameTimer timer = GameObject.FindFirstObjectByType<GameTimer>();
            Debug.Log(timer);
            if (timer != null)
            {
                timer.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}
