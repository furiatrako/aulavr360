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

public class VRMenuButton : MonoBehaviour {

    public Image bgImage;
    public Image selectionTimerFill;
    public float selectionTime = 1f;

    public AudioClip selectionSound;

    [Space]
    public bool isSubmitButton = false;

    private AudioSource aSource;

    [HideInInspector]
    public int questButtonNumber = -1;

    private bool isHover;
    public bool GetIsHover()
    {
        return isHover;
    }
    private float t = 1;

    private bool isSelected;
    public bool GetIsSelected()
    {
        return isSelected;
    }
    public float initFill;

    private void OnEnable()
    {
        Unselect();
    }

    public virtual void Start()
    {
        if (selectionSound != null)
        {
            GameObject audioObject = GameObject.Find("AudioSource");
            if(audioObject != null)
            {
                aSource = audioObject.GetComponent<AudioSource>();
            }
            if(aSource == null) aSource = gameObject.AddComponent<AudioSource>();
        }
        isHover = false;
        isSelected = false;
    }

    public virtual void FixedUpdate()
    {
        if (isHover)
        {
            Fill();
        }else
        {
            if(!isSelected)
            Unfill();
        }
    }

    public virtual void OnPointerHover()
    {
        initFill = selectionTimerFill.rectTransform.sizeDelta.x;
        t = 0;
        isHover = true;
    }

    public virtual void OnPointerExits()
    {
        initFill = selectionTimerFill.rectTransform.rect.width;
        t = 0;
        isHover = false;
    }

    private void Fill()
    {
        Lerp(initFill, bgImage.rectTransform.sizeDelta.x, selectionTime);
    }

    private void Unfill()
    {
        Lerp(initFill, 0, selectionTime/5);
    }

    private void Lerp(float init, float end, float time)
    {
        float width = Mathf.Lerp(init, end, t);
        selectionTimerFill.rectTransform.sizeDelta = new Vector2(width, selectionTimerFill.rectTransform.sizeDelta.y);
        if (t < 1)
        { // while t below the end limit...
          // increment it at the desired rate every update:
            t += Time.deltaTime / time;
        }
        else
        {
            TrySelect();
        }
    }

    private void TrySelect()
    {
        if (isHover && !isSelected)
        {
            Select();
        }
    }
    public virtual void Select()
    {
        Select(true);
    }

    public virtual void Select(bool playSound)
    {
        isSelected = true;
        if(selectionSound != null && playSound)
        {
            aSource.PlayOneShot(selectionSound);
        }
        if (SceneManager.GetActiveScene().name == "Intro") {
            IntroController ic = FindObjectOfType<IntroController>();
            if (ic != null)
            {
                ic.OnStartButtonclicked();
                Unselect();
                initFill = selectionTimerFill.rectTransform.rect.width;
                t = 0;
                isHover = false;
            }
        } else if (isSubmitButton)
        {
            RoomController rc = FindObjectOfType<RoomController>();
            if (rc != null)
            {
                rc.Submit();
                Unselect();
                initFill = selectionTimerFill.rectTransform.rect.width;
                t = 0;
                isHover = false;
            }
        }
        else
        {

            if (questButtonNumber != -1)
            {
                RoomController rc = FindObjectOfType<RoomController>();
                if (rc != null)
                {
                    
                    rc.SetSelectedButton(questButtonNumber);
                    Unselect();
                    initFill = selectionTimerFill.rectTransform.rect.width;
                    t = 0;
                    isHover = false;
                }
            }
            /*  MediaPlayerCtrl mpc = FindObjectOfType<MediaPlayerCtrl>();
              if(mpc != null)
              {
                  FindObjectOfType<RoomController>().SetCutscene((RoomController.cutscenes)nextCutscene);
                  mpc.m_strFileName = "video_" + (nextCutscene+1) + ".mp4";
                  Debug.Log("LOADING " + mpc.m_strFileName);
                  mpc.Load(mpc.m_strFileName);
                  Unselect();
                  initFill = selectionTimerFill.rectTransform.rect.width;
                  t = 0;
                  isHover = false;
              }*/
        }
    }

    public virtual void Unselect()
    {
        isSelected = false;
    }

    public void FullFill()
    {
        selectionTimerFill.fillAmount = 1;
    }
}
