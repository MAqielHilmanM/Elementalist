using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour {

    public List<SkillType> bInput;
    public int bIndex;

	// Use this for initialization
	void Start () {
        bInput = new List<SkillType>();
        bInput.Add(0);
        bInput.Add(0);
        bInput.Add(0);
        bIndex = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            switch (bIndex)
            {
                case 0:
                    bIndex++;
                    break;
                case 1:
                    bInput.Insert(0, InitSkill());
                    bIndex++;
                    break;
                case 2:
                    bInput.Insert(1, InitSkill());
                    bIndex++;
                    break;
                case 3:
                    bInput.Insert(2, InitSkill());
                    bIndex++;
                    break;
                default:
                    bIndex = 1;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            Debug.Log(CombineSkill(bInput));
        }
	}

    public enum SkillType {
        AIR,
        WATER,
        Null
    }

    SkillType InitSkill() {
        if (Input.GetKeyDown(KeyCode.X))
        {
            return SkillType.AIR;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            return SkillType.WATER;
        }
        else
            return SkillType.Null;
    }

    string CombineSkill(List<SkillType> skill) {
        int tmp1 = 0;
        int tmp2 = 0;
        int tmp3 = 0;
        for (int i = 0; i < skill.Count; i++) {
            if (skill[i] == SkillType.AIR)
            {
                tmp1++;
            }
            else if (skill[i] == SkillType.WATER)
            {
                tmp2++;
            }
            else {
                tmp3++;
            }
        }


        return initCombine(tmp1,tmp2,tmp3);
    }

    string initCombine(int skill1,int skill2,int skillNull) {
        if (skillNull != 0)
        {
            if (skill1 == 3)
                return "Tornado";
            else if (skill2 == 3)
                return "Tsunami";
            else if (skill2 == 2 && skill1 == 1)
                return "Ice Sword";
            else
                return "Ice Wall";
        }
        else
            return "Invalid Element";
    }
}
