using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public float JumpPlatformPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("점프대 충돌 확인용");

            Rigidbody body = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 v = body.velocity;
            v.y = 0f;
            body.velocity = v;

            body.AddForce(Vector3.up * JumpPlatformPower, ForceMode.Impulse);
        }
    }
}
