using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushObject : MonoBehaviour
{
    [SerializeField] public float forceMagnitude;
    public PlayerController playerctrl;
    public Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
    }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            var rigidBody = hit.collider.attachedRigidbody;

            if (rigidBody != null)
            {
                var forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
                anim.SetBool("isPushing", true);
            }
            else
            {
                anim.SetBool("isPushing", false);
            }
        }
}
