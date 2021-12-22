using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CastBarrier : MonoBehaviour
{
    public GameObject barrier;
    [SerializeField] InputActionReference controllerActionTrigger;

    private Animator _handAnimator;

    private void Awake()
    {
        controllerActionTrigger.action.performed += TriggerPress;
        controllerActionTrigger.action.canceled += TriggerPressEnd;

        _handAnimator = GetComponent<Animator>();
    }

    void TriggerPress(InputAction.CallbackContext obj)
    {
        barrier.SetActive(true);
    }

    void TriggerPressEnd(InputAction.CallbackContext obj)
    {
        barrier.SetActive(false);
    }
}
