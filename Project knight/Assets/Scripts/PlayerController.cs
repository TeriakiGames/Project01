using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    Vector2 inputMovement = Vector2.zero;
    [SerializeField] Vector3 rawInputMovement;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] bool isFacingRight;

    [SerializeField] float speed;

    public void OnMovement(InputAction.CallbackContext context)
    {
        //Read the input value from a controller.
        inputMovement = context.ReadValue<Vector2>();
        //Re-direct the Vector2 input to a Vector3 for 3D movement.
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y).normalized * speed;

        Flip(inputMovement.x);
    }

    private void Start()
    {
        isFacingRight = true;
    }

    private void FixedUpdate()
    {
        //Move Character base on input.
        rigid.MovePosition(rigid.position + rawInputMovement * Time.deltaTime);
    }

    private void Update()
    {
        //check to see if player is moving.
        float movement = rawInputMovement.sqrMagnitude;
        //set the float (movement) animation to the speed of the character.
        anim.SetFloat("movement", movement);
    }

    private void Flip(float direction)
    {
        if (direction > 0 && !isFacingRight || direction < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 scaling = transform.localScale;

            scaling.x *= -1;

            transform.localScale = scaling;
        }

    }
}