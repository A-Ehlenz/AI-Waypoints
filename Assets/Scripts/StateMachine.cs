using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State //can be used to replace strings in code
{
    Wander,
    Stop
}

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private State state;

    private SpriteRenderer sprite = null;
    private WaypointAI waypointAI = null;

    private IEnumerator WanderState() //IEnumerator is used for co-routines
    {
        Debug.Log("Wander: Enter");
        sprite.color = Color.green;

        while (state == State.Wander) //while is like for but will continue until state is no longer "Wander"
        {
            Debug.Log("Wander: Inside");
            waypointAI.isAIMoving = true;
            yield return null; //come back the next frame
        }
        Debug.Log("Wander: Exit");
        NextState();
    }

    private IEnumerator StopState()
    {
        Debug.Log("Stop: Enter");
        sprite.color = Color.red;

        while (state == State.Stop)
        {
            waypointAI.isAIMoving = false;
            yield return null;
        }
        Debug.Log("Stop: Exit");
        NextState();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null)
        {
            Debug.LogError("Hey Coder, sprite is null, there is no SpriteRenderer on this object.");
        }

        waypointAI = GetComponent<WaypointAI>();
        if (waypointAI == null)
        {
            Debug.LogError("Hey Coder, waypointAi is null, there is no WaypointAI on this object.");
        }

        NextState();
    }

    private void NextState()
    {
        switch (state)
        {
            case State.Wander:
                StartCoroutine(WanderState()); //coroutines allow for the code to stop and let other code while still coming back to it later
                break;

            case State.Stop:
                StartCoroutine(StopState());
                break;

            default:
                StartCoroutine(StopState());
                break;
        }
    }
}
