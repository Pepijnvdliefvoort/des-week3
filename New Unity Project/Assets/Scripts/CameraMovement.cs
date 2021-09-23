using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour {
    Vector2 input;
    List<GameObject> inventory;

    [SerializeField]
    public int Speed = 5;

    // Start is called before the first frame update
    void Start() {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context) {
        input = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context) {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Clickable") {
                inventory.Add(hit.transform.gameObject);
                Destroy(hit.transform.gameObject);
                return;
            }

            if (hit.transform.tag == "Vault") {
                if (inventory.Count >= 3) {
                    Debug.Log("open");
                }
            }
        }
    }

    public void Move() {
        Vector3 Xaxis = input.x * transform.right;
        Vector3 Yaxis = input.y * transform.forward;

        transform.Rotate(new Vector3(0, input.x / 2, 0));

        Vector3 direction = (Xaxis + Yaxis).normalized * Time.deltaTime * Speed;

        Ray ray = new Ray(transform.position, transform.forward);
        if (!Physics.Raycast(ray, 1)) {
            transform.position += Yaxis / 25;
        }
    }
}
