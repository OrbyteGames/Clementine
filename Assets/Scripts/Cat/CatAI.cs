using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatAI : MonoBehaviour {


    enum state { WAITING_PLAYER, WAITING_PUZZLE, MOVING_TO_POINT, CINEMATIC_STATE };

    public Transform playerTransform;

    private float dist;
    private state actualState;
    public bool solved = false;
        private bool cinematic_ended;
    private int torches_enabled;
    private Puzzle_solved_cinematic pcs;
    public GameObject actualMarker;
    public GameObject targetMarker;
    public NavMeshAgent agent;
    public float moveNextDistance = 4.0f;
    public float movePreviousDistance = 30.0f;

    // Use this for initialization
    void Start() {
        solved = false;
        cinematic_ended = false;
        torches_enabled = 0;
        dist = 0.0f;
        actualState = state.WAITING_PUZZLE;
        pcs = gameObject.GetComponent<Puzzle_solved_cinematic>();
    }

    // Update is called once per frame
    void Update() {
        switch (actualState) {
            case state.WAITING_PUZZLE:
                if (solved) {
                    solved = false;
                    targetMarker = actualMarker.GetComponent<MarkerScript>().getNextMarker();
                    if (targetMarker != null)
                    {
                        agent.SetDestination(targetMarker.gameObject.transform.position);
                        actualState = state.MOVING_TO_POINT;
                    }
                    if (torches_enabled > 3)
                    {
                        //start cinematic finish
                    }
                }
                break;
            case state.WAITING_PLAYER:
                dist = Vector3.Distance(playerTransform.position, gameObject.transform.position);
                if (!(dist > moveNextDistance && dist <= movePreviousDistance))
                {
                    if (dist <= moveNextDistance) targetMarker = actualMarker.GetComponent<MarkerScript>().getNextMarker();
                    else if (dist > movePreviousDistance) targetMarker = actualMarker.GetComponent<MarkerScript>().getPreviousMarker();
                    if (targetMarker != null)
                    {
                        agent.SetDestination(targetMarker.gameObject.transform.position);
                        actualState = state.MOVING_TO_POINT;
                    }
                }
                break;
            case state.CINEMATIC_STATE:
                if (cinematic_ended)
                {
                    targetMarker = actualMarker.GetComponent<MarkerScript>().getNextMarker();
                    agent.SetDestination(targetMarker.gameObject.transform.position);
                    actualState = state.MOVING_TO_POINT;
                    cinematic_ended = false;
                }
                break;
            case state.MOVING_TO_POINT:
                float pointDistance = Vector3.Distance(gameObject.transform.position, actualMarker.GetComponent<MarkerScript>().getNextMarker().gameObject.transform.position);
                if (pointDistance < 1.0f) {
                    actualMarker = targetMarker;
                    switch (actualMarker.GetComponent<MarkerScript>().getType())
                    {
                        case MarkerScript.markerType.OBJECTIVE_POINT:
                            actualState = state.WAITING_PLAYER;
                            break;
                        case MarkerScript.markerType.PASS_BY:
                            targetMarker = actualMarker.GetComponent<MarkerScript>().getNextMarker();
                            agent.SetDestination(targetMarker.gameObject.transform.position);
                            break;
                        case MarkerScript.markerType.PUZZLE_POINT:
                            actualState = state.WAITING_PUZZLE;
                            break;
                        case MarkerScript.markerType.FISHBONES:
                            actualState = state.CINEMATIC_STATE;
                            pcs.StartCinematic(torches_enabled);
                            ++torches_enabled;
                            //  Start glowing effect script
                            break;
                    }
                }
                break;

        }
    }

    public void setSolved() {
        solved = true;
    }

    public void setCinematicFinished() {
        cinematic_ended = true;
    }
}
