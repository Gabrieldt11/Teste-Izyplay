using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider kCollider;
    public GameObject panel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        kCollider = GetComponent<BoxCollider>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        Knife_Movement();
    }

    void Knife_Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
            rb.AddForce(Vector3.right * 0.5f, ForceMode.Impulse);
            rb.AddTorque(0f, 0f, -5f, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            print("sla");
            SceneManager.LoadScene("GameScene");
        }

        else if (other.CompareTag("Object"))
        {
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Finish"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
