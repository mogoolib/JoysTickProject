using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEventArgs
{
    public int id;
    public GameObject obj;
}

public class UISkillControl : MonoBehaviour {

    public delegate void SkillButtonDelegate(SkillEventArgs args);
    public SkillButtonDelegate skillButtonDelegate;

    private Button[] skillbtn;

	void Start () {
        skillbtn = GetComponentsInChildren<Button>();

        for (int i = 0;i < skillbtn.Length; ++i) {
            SkillEventArgs args = new SkillEventArgs();
            args.id = i + 1;
            args.obj = skillbtn[i].gameObject;
            skillbtn[i].onClick.AddListener(()=>OnClicked(args));
        }
    }

    void OnClicked(SkillEventArgs args)
    {
        if (skillButtonDelegate != null) {
            skillButtonDelegate(args);
        }
    }
}
