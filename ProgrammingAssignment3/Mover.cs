using System;
using UnityEngine;

/// <summary>
/// Mover the game object back and forth
/// </summary>	
public class Mover : MonoBehaviour
{
    #region Fields


    const float MoveAmountPerSecond = 5;
    const float TimerDuration = 1;

    Timer directionTimer;
    int directionMultiplier = 1;

    #endregion

    #region Properties - for autograder use only!

    /// <summary>
    /// Gets and sets the position of the game object
    /// </summary>
    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    /// <summary>
    /// Gets the direction timer so the autograder can
    /// update the timer every frame
    /// </summary>
    public Timer DirectionTimer
    {
        get { return directionTimer; }
    }

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    public void Start()
    {
        transform.position = new Vector3(-2.5f, 0, 0);

        directionTimer = gameObject.AddComponent<Timer>();
        directionTimer.Duration = TimerDuration;
        directionTimer.Run();

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>	
    public void Update()
    {
        if (directionTimer.Finished)
        {
            directionMultiplier *= -1;
            directionTimer.Run();
        }

        Vector3 position = transform.position;
        position.x += Time.deltaTime * MoveAmountPerSecond * directionMultiplier;
        transform.position = position;
    }

    #endregion
}
