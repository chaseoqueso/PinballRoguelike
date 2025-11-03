using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [Tooltip("Whether this flipper should respond to right input or left input")] 
    [SerializeField] private bool isRightFlipper;
    [Tooltip("The strength of the flipper")] 
    [SerializeField] private float flipperVelocity = 1000;

    private InputAction input;
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        if (isRightFlipper)
        {
            input = InputSystem.actions.FindAction("Right");
        }
        else
        {
            input = InputSystem.actions.FindAction("Left");
        }
    }

    void Update()
    {
        float targetVelocity = 0;
        float velocitySign = isRightFlipper ? 1 : -1;
        if (input.ReadValue<float>() > 0)
        {
            targetVelocity = flipperVelocity * velocitySign;
        }
        else
        {
            targetVelocity = -flipperVelocity * velocitySign;
        }
            
        var motor = hinge.motor;
        motor.targetVelocity = targetVelocity;
        hinge.motor = motor;
    }
}
