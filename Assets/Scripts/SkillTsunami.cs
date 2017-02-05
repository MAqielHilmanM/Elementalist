using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTsunami : MonoBehaviour {

    public bool castSkill;
    private float timer;

	// Use this for initialization
	void Start () {
        castSkill = false;
        timer = 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (castSkill)
        {
            this.gameObject.SetActive(true);
            timer -= Time.deltaTime;
         }

        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void setCastSkill(bool castSkill) {
        this.castSkill = castSkill;
    }
}
