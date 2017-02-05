using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour {

    public List<SkillType> bInput;
    public int bIndex;
    public string bSkillName;

    public GameObject Skill_tornado;
    public GameObject Skill_icewall;
    public GameObject Skill_icesword;
    public GameObject Skill_tsunami;

    public float skillTime;

    // Use this for initialization
    void Start () {
        bInput = new List<SkillType>();
        bInput.Add(SkillType.Null);
        bInput.Add(SkillType.Null);
        bInput.Add(SkillType.Null);
        bIndex = 1;
        bSkillName = "";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            switch (bIndex)
            {
                case 0:
                    bInput.Clear();
                    bIndex++;
                    break;
                case 1:
                    bInput.RemoveAt(0);
                    bInput.Insert(0, InitSkill());
                    bIndex++;
                    break;
                case 2:
                    bInput.RemoveAt(1);
                    bInput.Insert(1, InitSkill());
                    bIndex++;
                    break;
                case 3:
                    bInput.RemoveAt(2);
                    bInput.Insert(2, InitSkill());
                    bIndex++;
                    break;
                case 4:
                    SkillType tmp1 = bInput[1];
                    SkillType tmp2 = bInput[2];
                    SkillType tmp3 = InitSkill();

                    bInput.Clear();
                    bInput.Add(tmp1);
                    bInput.Add(tmp2);
                    bInput.Add(tmp3);
                    break;
                default:
                    bIndex = 1;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            bSkillName = CombineSkill(bInput);
        }

        if (skillTime > 0) {
            skillTime -= Time.deltaTime;
        }

        if (skillTime <= 0) {
            Skill_icewall.SetActive(false);
            Skill_icesword.SetActive(false);
            Skill_tsunami.SetActive(false);
            Skill_tornado.SetActive(false);
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

        Debug.Log("Skill Count = "+skill.Count);
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
        Debug.Log("Air :"+skill1);
        Debug.Log("Water :" + skill2);
        Debug.Log("null :" + skillNull);

        if (skillNull == 0 && skillTime <= 0)
        {
            if (skill1 == 3)
            {
                skillTime = 2;
                Skill_tornado.SetActive(true);
                return "Tornado";
            }
            else if (skill2 == 3)
            {
                skillTime = 1;
                Skill_tsunami.SetActive(true);
                return "Tsunami";
            }
            else if (skill2 == 2 && skill1 == 1)
            {
                skillTime = 3;
                Skill_icesword.SetActive(true);
                return "Ice Sword";
            }
            else
            {
                skillTime = 2;
                Skill_icewall.SetActive(true);
                return "Ice Wall";
            }
        }
        else
        {
            return "Invalid Element";
        }
    }
}
