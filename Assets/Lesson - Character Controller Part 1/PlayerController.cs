using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movement_speed = 5f;
    [SerializeField] float rotation_speed = 500f;

    private CharacterController character_controller;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();          
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float move_amount = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        Vector3 velocity = new Vector3(horizontal, 0f, vertical).normalized * movement_speed;

        character_controller.Move(velocity * Time.deltaTime);

        if(move_amount > 0)
        {
            var target_rotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);
        }
    }
}
