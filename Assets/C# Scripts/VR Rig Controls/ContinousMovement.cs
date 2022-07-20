using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour
{
    // Create XRNode object to be able to select what device/source to listen to
    public XRNode InputSource;

    // Create XROrigin object
    private XROrigin Rig;

    // Create a vector 2 object to store joystick data
    private Vector2 InputAxis;

    // Create a character controller object
    private CharacterController Character;

    // Create variable to change character's movement speed
    public float Speed = 10f;

    // Create variable for gravity accelaration
    private float Gravity = -9.81f;

    // Create variable to define falling speed of character object
    private float FallingSpeed;

    // Create LayerMask object
    public LayerMask GroundLayer;

    // Start is called before the first frame update
    void Start()
    {
        // We can attach this object from the inspector
        Character = GetComponent<CharacterController>();

        // Get the Origin from the cemera 
        Rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        // Access device through node
        InputDevice Device = InputDevices.GetDeviceAtXRNode(InputSource);
        Device.TryGetFeatureValue(CommonUsages.primary2DAxis, out InputAxis);
    
    }

    // Movement will be computed each time unity updates the our physics
    //rather than in the Update() function which will do it constantly
    private void FixedUpdate()
    {
        // Extract the head yaw movement from the VR Camera (angle)
        Quaternion HeadYaw = Quaternion.Euler(0, Rig.Camera.transform.eulerAngles.y, 0);

        // Create a vector 3 to store the dierction we want to move relative
        //to input from joystick (Input Source)
        Vector3 Direction = HeadYaw * new Vector3(InputAxis.x, 0, InputAxis.y);

        // Move the character object (update)
        Character.Move(Direction * Time.deltaTime * Speed);

        // Implement gravity
        bool IsGrounded = CheckIfGrounded();
        if (IsGrounded)
        {
            FallingSpeed = 0;
        }
        else
        {
            FallingSpeed += Gravity * Time.fixedDeltaTime;
        }
        Character.Move(Vector3.up * FallingSpeed * Time.deltaTime);

    }

    // Tell us if on ground
    bool CheckIfGrounded()
    {
        Vector3 RayStart = transform.TransformPoint(Character.center);
        float RayLength = Character.center.y + 0.01f;
        bool HasHit = Physics.SphereCast(RayStart, Character.radius, Vector3.down, out RaycastHit HitInfo, RayLength, GroundLayer);
        return HasHit;
    }
}
