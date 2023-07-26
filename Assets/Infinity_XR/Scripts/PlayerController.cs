using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private  float speedLocomotion = 10;
    [SerializeField] private float speedRotation = .2f;
    [SerializeField] private float speedVertical =  .2f;
    private CharacterController player;
    private Vector3 PlayerMovementInput;
    private Vector3 PlayerRotateInput;
    private float xRot;

    void Start() {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
        MoveCamera();
    }

    void MovePlayer() {
        Vector3 movement = Vector3.zero;

        float moveUp = Input.GetAxis("MoveUp");
        float moveDown = Input.GetAxis("MoveDown");
        float verticalMovement = -moveDown + moveUp;

        if(player.isGrounded)
            movement = new Vector3(Input.GetAxis("Horizontal"), verticalMovement, Input.GetAxis("Vertical"));
        else
            movement = new Vector3(Input.GetAxis("Horizontal"), verticalMovement, Input.GetAxis("Vertical"));

        movement *= speedLocomotion;

        Quaternion direction = Quaternion.Euler(x:0, y:player.transform.eulerAngles.y, z:0);
        // Move the controller
        var move = direction * movement;
        player.Move(move * Time.deltaTime);
    }

    void MoveCamera() {
        transform.Rotate(new Vector3(0, Input.GetAxis("LookHorizontal") * speedRotation, 0));
    }
}
