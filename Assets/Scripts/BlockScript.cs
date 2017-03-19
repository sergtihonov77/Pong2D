using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int hitsToKill;
    public int points;
    private int _numberOfHits;
    private GameObject _player;

    void Start ()
    {
        _numberOfHits = 0;
        _player = GameObject.Find("Player");
        
    }
	
	void Update ()
    {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _numberOfHits++;

            // If the number of hits exceeds the maximum, then we give points to player and destroy the object
            if (_numberOfHits == hitsToKill)
            {
                _player.SendMessage("addPoints",points);
                Destroy(this.gameObject);
            }

        }
    }

  

}
