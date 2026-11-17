using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
public float moveSpeed = 4f;
public float mouseSensitivity = 0.15f;
public Transform playerCamera;
public FirstPersonInteraction interaction;
private CharacterController controller;
private Vector2 moveInput;
private Vector2 lookInput;
private float cameraPitch = 0f;
void Awake()
{
controller = GetComponent<CharacterController>();
}
void Start()
{
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
}
public void OnMove(InputValue value)
{
moveInput = value.Get<Vector2>();
}
public void OnLook(InputValue value)
{
lookInput = value.Get<Vector2>();
}
void Update()
{
Vector3 direction =
transform.right * moveInput.x +
transform.forward * moveInput.y;
direction = Vector3.ClampMagnitude(direction, 1f);
controller.SimpleMove(direction * moveSpeed);
if (Cursor.lockState == CursorLockMode.Locked)
{
float mouseX = lookInput.x * mouseSensitivity;
float mouseY = lookInput.y * mouseSensitivity;
transform.Rotate(Vector3.up * mouseX);
cameraPitch -= mouseY;
cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);
playerCamera.localRotation =
Quaternion.Euler(cameraPitch, 0f, 0f);
}
if (Keyboard.current != null &&
Keyboard.current.escapeKey.wasPressedThisFrame)
{
Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
}
if (Mouse.current != null &&
Mouse.current.leftButton.wasPressedThisFrame &&
Cursor.lockState == CursorLockMode.None)
{
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;
}
}
public void OnInteract(InputValue value)
{
if (!value.isPressed) return;
if (interaction != null)
interaction.TryInteract();
}
}
