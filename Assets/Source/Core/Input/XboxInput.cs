using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed internal class XboxInput : MonoBehaviour
{
    #region Values
    // Defines the instance of this class.
    private static XboxInput singleton;

    // Defines the quantity of connected controllers.
    internal static int connectedControllerCount;

    public enum Button
    {
        Guide,
        Start,
        Back,
        A,
        B,
        X,
        Y,
        LB,
        RB,
        LeftStick,
        RightStick,
        DpadUp,
        DpadDown,
        DpadLeft,
        DpadRight,
        RightTrigger,
        LeftTrigger
    }
    public enum Direction
    {
        LeftStick,
        RightStick,
        Dpad
    }
    public enum Axis
    {
        LeftStickX,
        LeftStickY,
        RightStickX,
        RightStickY,
        LeftTrigger,
        RightTrigger
    }

    private List<Vibration> _vibrations = new List<Vibration>();
    private float[] _controllerVibrations;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateVibrations();
        UpdateStates();
    }
    #endregion

    #region Functions
    private void Initialize()
    {
        // Create instance, or destroy self if duplicate
        if (singleton != null)
        {
            Destroy(this.gameObject);
            return;
        }
        singleton = this;
        DontDestroyOnLoad(this.gameObject);

        _controllerVibrations = new float[] { 0, 0, 0, 0 };
    }

    private void UpdateStates()
    {
        connectedControllerCount = 0;
        // No XInput support
    }

    public static bool IsConnected(int gamePad)
    {
        return false;
    }

    public static bool GetButton(int gamePad, Button button)
    {
        return false;
    }
    public static bool GetButtonUp(int gamePad, Button button)
    {
        return false;
    }
    public static bool GetButtonDown(int gamePad, Button button)
    {
        return false;
    }

    public static float GetAxis(int gamePad, Axis axis)
    {
        return 0;
    }
    public static Vector2 GetDirection(int gamePad, Direction direction)
    {
        return Vector2.zero;
    }

    private void UpdateVibrations()
    {
        _controllerVibrations = new float[] { 0, 0, 0, 0 };
        for (int i = 0; i < _vibrations.Count; i++)
        {
            Vibration vibration = _vibrations[i];
            float duration = vibration.killTime - vibration.startTime;
            float timeRemaining = vibration.killTime - Time.time;

            _controllerVibrations[vibration.controllerId] += vibration.intensity * (timeRemaining / duration);

            if (Time.time >= vibration.killTime)
            {
                i--;
                _vibrations.Remove(vibration);
            }
        }
    }

    public static void AddVibration(Vibration vibration)
    {
        singleton._vibrations.Add(vibration);
    }

    public static void ClearAllVibrations()
    {
        singleton._vibrations.Clear();
    }
    public static void ClearControllerVibrations(int controllerId)
    {
        singleton._vibrations.RemoveAll(v => v.controllerId == controllerId);
    }
    #endregion
}