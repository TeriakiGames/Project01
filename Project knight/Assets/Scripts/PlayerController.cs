using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputManager input;

    public float speed;
    public Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        OnMovement();
    }

    private void OnMovement()
    {
        transform.Translate(input.rawInputMovement * Time.deltaTime * speed);
    }

    private void Initiate()
    {
        //Check to see if player has it's components.
        if (input == null)
        {
            input = FindObjectOfType<InputManager>();
            Debug.Log("Found inputManager");
        }
        else
            Debug.Log("Could not find InputManager script, are you missing a reference?");
    }
}
