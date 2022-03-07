using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
   [SerializeField]
   private PlayerInput PlayerInput;
   [SerializeField]
   private int priorityBoostAmount = 10;
   [SerializeField]
   private Canvas thirdPersonCanvas;
   [SerializeField]
   private Canvas aimCanvas;

   private CinemachineVirtualCamera virturalCamera;
   private InputAction aimAction;

   private void Awake()
   {
      virturalCamera = GetComponent<CinemachineVirtualCamera>();
      aimAction = PlayerInput.actions["Aim"];

   }

   private void OnEnable()
   {
      aimAction.performed += _ => StartAim();
      aimAction.canceled += _ => CancelAim();
   }
   private void OnDisable()
   {
      aimAction.performed -= _ => StartAim();
      aimAction.canceled -= _ => CancelAim();
   }
   private void StartAim()
   {
      virturalCamera.Priority += priorityBoostAmount;
      aimCanvas.enabled = true;
      thirdPersonCanvas.enabled = false;
   }
   private void CancelAim()
   {
      virturalCamera.Priority -= priorityBoostAmount;
      aimCanvas.enabled = false;
      thirdPersonCanvas.enabled = true;
   }
}
