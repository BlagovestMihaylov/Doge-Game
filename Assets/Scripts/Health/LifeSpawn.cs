using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawn : MonoBehaviour
{
public float lifeTime = 10f;
	
	// Update is called once per frame
	void Update () {
		if(lifeTime > 0) {
			lifeTime -= Time.deltaTime;
			if(lifeTime <= 0) {
				Destruction();
			}
		}

		if(this.transform.position.y <= -120) {
			Destruction();
		}
	}

	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.name == "destroyer") {
			Destruction();
		}
	}

	void Destruction() {
		Destroy(this.gameObject);
	}
}
