using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] BallPhysics ball;

    private bool running = false;
    void Start()
    {
        line.SetPosition(0, ball.transform.position);
    }

    void Update()
    {
        if (!running)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ball.Run((Input.mousePosition - Camera.main.WorldToScreenPoint(ball.transform.position + Vector3.forward * Camera.main.transform.position.z)).normalized);
                running = true;
                line.gameObject.SetActive(false);
            } else
            {
                line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
