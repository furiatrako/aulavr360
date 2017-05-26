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

public class ShowRoomController : MonoBehaviour {
    public GameObject preview;
    public GameObject title;
    public float titleTranslationAmount = 3.2f;
    public GameObject description;
    public float descriptionTranslationAmount = 3.7f;
    public GameObject experienceRoomButton;
    public float buttonTranslationAmount = 20;
    public Transform buttonFinalPosition;
    public InitialTextController initText;
    public float initialTextFadeDuration = 1;
    public Texture2D[] roomPreviews;
    
    private int currentRoom;


    private enum RoomState
    {
        Invisible,
        Fade,
        Visible,
    }
    private RoomState state;
    private FadeTexture previewFT;

    // Use this for initialization
    void Start () {
        previewFT = preview.GetComponent<FadeTexture>();
        state = RoomState.Invisible;
	}
	
	// Update is called once per frame
	void Update () {
        if(state == RoomState.Fade && !previewFT.IsFade)
        {
            ShowText();
            
        } 
	}
    

    public void StartFadeIn()
    {
        initText.FadeOut(initialTextFadeDuration);
        Invoke("FadeIn", initialTextFadeDuration);
    }
    private void FadeIn()
    {
        if (state != RoomState.Visible)
        {
            experienceRoomButton.gameObject.SetActive(true);
            state = RoomState.Fade;
            previewFT.FadeIn();
        }
    }

    private void ShowText()
    {
        state = RoomState.Visible;

        Hashtable ht = new Hashtable();
        ht.Add("amount", Vector3.left * titleTranslationAmount);
        ht.Add("space", Space.Self);
        ht.Add("time", 1.5f);
        ht.Add("easytype", iTween.EaseType.easeInOutQuad);
        iTween.MoveBy(title, ht);

        Hashtable ht2 = new Hashtable();
        ht2.Add("amount", Vector3.right * descriptionTranslationAmount);
        ht2.Add("space", Space.Self);
        ht2.Add("time", 1.5f);
        ht2.Add("easytype", iTween.EaseType.easeInOutQuad);
        iTween.MoveBy(description, ht2);

        Hashtable ht3 = new Hashtable();
        ht3.Add("position", buttonFinalPosition.position);
        ht3.Add("local", false);
        ht3.Add("delay", 0.2f);
        ht3.Add("time", 1.5f);
        ht3.Add("easytype", iTween.EaseType.easeInOutQuad);
        ht3.Add("oncomplete", "ShowText");
        ht3.Add("oncompletetarget", experienceRoomButton);
        iTween.MoveTo(experienceRoomButton, ht3);
    }


    
    

    public void SetPreviews (string room)
    {
        int roomNumber = int.Parse(room.ToCharArray()[room.ToCharArray().Length - 1] + "");
        Texture2D texture = roomPreviews[roomNumber - 1];
        preview.GetComponent<Renderer>().material.mainTexture = texture;
    }
}
