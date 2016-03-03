using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed = 3;
    private Transform _tranform;
    private Vector2 _currentPos;

    // Use this for initialization
    void Start () {
        //link the tranform - make refrence with transform componenent
        this._tranform = gameObject.GetComponent<Transform>();
        this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
        this._currentPos = this._tranform.position;
        this._currentPos -= new Vector2(0,this.speed);
        this._tranform.position = this._currentPos;
        if (this._currentPos.y <= -480)
        {
            this._Reset();
        }
    }

	private void _Reset() {
		Vector2 resetPosition = new Vector2 (0.0f, 480f);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
