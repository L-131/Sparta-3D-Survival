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
            Debug.Log("������ �浹 Ȯ�ο�");

            Rigidbody body = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 v = body.velocity;
            v.y = 0f;
            body.velocity = v;

            body.AddForce(Vector3.up * JumpPlatformPower, ForceMode.Impulse);
        }
    }
}
