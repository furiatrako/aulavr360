///    Aula RV 360 is a professional training environment in virtual reality
///    with 360 videos.
///    Copyright(C) 2017  Twin Force SL - http://www.twinforce.es
///    Contact us at contact@twinforce.es
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
///    (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
/// GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program.If not, see<http://www.gnu.org/licenses/>.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour {
    private bool isInternal = true;

    public GameObject sphereExternal;
    public GameObject sphereInternal;
    [Space]
    public MediaPlayerCtrl mpc;
    public AudioSource aSource;
    public AudioClip acEnclosure;
    public AudioClip acSurvey1;
    public AudioClip acSurvey2;
    public AudioClip acSurvey3;
    [Space]
    public GameObject questionary;
    public Text question;
    public GameObject[] buttons;
    public GameObject[] checks;
    public GameObject questionaryBig;
    public Text questionBig;
    public GameObject submitButton;
    [Space]
    public Renderer reticleRenderer;

    [HideInInspector]
    public int selectedButton = -1;

    private int video = 1;

    private string result = "";

    public enum cutscenes
    {
        intro,
        arrival,
        letspeak,
        technicalaspects,
        genericaspects,
        letsask,
        enclosure,
        consideration,
        survey1,
        survey2,
        survey3,
        end,
    }
    private cutscenes currentCutscene = cutscenes.arrival;
    private bool isTechShowed = false;
    private bool isGenericShowed = false;


    // Use this for initialization
    void Start () {
        mpc.OnEnd += OnVideoEnd;
        mpc.OnReady += OnVideoReady;
        mpc.m_strFileName = "video_"+video+".mp4";
        mpc.Load(mpc.m_strFileName);
    }



    public void OnVideoEnd()
    {
        bool noButton = true;
            questionary.SetActive(true);
        ShowReticle();
            
        int cCutscene = (int)currentCutscene;

        question.text = Questionary.questions[cCutscene, 0];
        questionBig.text = Questionary.questions[cCutscene, 0];
            questionaryBig.SetActive((currentCutscene == cutscenes.consideration));
            questionBig.gameObject.SetActive((currentCutscene == cutscenes.consideration));
            question.gameObject.transform.parent.transform.parent.gameObject.SetActive(!(question.text == ""));
        
            for (int i = 0; i < 3; i++)
            {
                if (Transitions.cutscenes[cCutscene, i] != -1)
                {
                    VRMenuButton vrButton = buttons[i].GetComponentInChildren<VRMenuButton>();
                    vrButton.questButtonNumber = i;

                    Text txt = buttons[i].GetComponentInChildren<Text>();
                    txt.text = Questionary.questions[cCutscene, i+1];
                    if(!(Transitions.cutscenes[cCutscene, i] == 3 && isTechShowed) && !(Transitions.cutscenes[cCutscene, i] == 4 && isGenericShowed))
                    {
                        buttons[i].SetActive(true);
                    noButton = false;
                    }
                }
            }

        if (currentCutscene == cutscenes.consideration)
        {
            aSource.PlayOneShot(acEnclosure);
        }
        else if (currentCutscene == cutscenes.survey1)
        {
            aSource.PlayOneShot(acSurvey1);
        }else if (currentCutscene == cutscenes.survey2)
        {
            aSource.PlayOneShot(acSurvey2);
        }
        else if (currentCutscene == cutscenes.survey3)
        {
            aSource.PlayOneShot(acSurvey3);
        }

        if (!noButton) submitButton.SetActive(false);


    }

    public void SetCutscene (cutscenes cutscene)
    {
        currentCutscene = cutscene;
    }

    public void OnVideoReady()
    {
        if (currentCutscene == cutscenes.technicalaspects) isTechShowed = true;
        if (currentCutscene == cutscenes.genericaspects) isGenericShowed = true;
        for (int i = 0; i < 3; i++)
        {
            
                buttons[i].SetActive(false);
                checks[i].SetActive(false);
            
        }
        questionary.SetActive(false);
        mpc.Play();
        HideReticle();
        if ((int)currentCutscene < (int)cutscenes.enclosure)
        {
            result += "Escena " + (int)currentCutscene + "\n";
        }
        Debug.Log("Escene " + currentCutscene);
    }

    public void Submit()
    {
        aSource.Stop();
        Debug.Log("SELECTED BUTTON " + selectedButton);
        if(currentCutscene != cutscenes.end)
        {
            
            if(currentCutscene == cutscenes.survey2)
            {
                result += "Pregunta 1: " + Questionary.questions[(int)currentCutscene, selectedButton+1] + "\n";
            }else if (currentCutscene == cutscenes.survey3)
            {
                result += "Pregunta 2: " + Questionary.questions[(int)currentCutscene, selectedButton+1] + "\n";
            }

            LoadVideo();
        }
        else
        {
            SendInfo();
            SceneManager.LoadScene("Preparation");
        }
    }

    public void LoadVideo()
    {
        int cCutscene = (int)currentCutscene;
        int nextCutscene = Transitions.cutscenes[cCutscene, selectedButton];
        if (currentCutscene >= cutscenes.enclosure)
        {
            nextCutscene = (int)currentCutscene+1 ;
            mpc.m_strFileName = "plano_recurso.mp4";
        }else
        {
            mpc.m_strFileName = "video_" + (nextCutscene) + ".mp4";
        }
         SetCutscene((RoomController.cutscenes)nextCutscene);
        mpc.Load(mpc.m_strFileName);
    }

    private void SendInfo()
    {
        SendMail sm = FindObjectOfType<SendMail>();
        System.DateTime now = System.DateTime.Now;
        sm.subject = "Resultado Sesion - " + now.Day + "/" + now.Month + "/" + now.Year + " " + now.Hour + now.Minute;
        sm.body = result;
        sm.Send();
    }

    public void SetSelectedButton(int index)
    {
        selectedButton = index;
        foreach (var check in checks)
        {
                check.SetActive(checks[index].Equals(check));
        }

        submitButton.SetActive(true);
    }
    Color reticleColor = Color.red;
    private void ShowReticle()
    {
        reticleRenderer.material.color = reticleColor;
    }

    private void HideReticle()
    {
        reticleColor = reticleRenderer.material.color;
        reticleRenderer.material.color = new Color(0, 0, 0, 0);
    }
}
