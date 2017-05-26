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

public class LoadingFade : MonoBehaviour {
    public Image bg;
    public Image starBase;
    public Image starStaticFill;
    public Image starFill;
    public Text text;
    public float fadeDuration = 0.5f;

    public void Start()
    {
        if(bg.canvasRenderer.GetAlpha()>0.9f)
        FadeOut();
    }

    public void FadeIn()
    {
        starFill.gameObject.SetActive(true);
        bg.canvasRenderer.SetAlpha(0.0f);
        starBase.canvasRenderer.SetAlpha(0.0f);
        text.canvasRenderer.SetAlpha(0.0f);
        bg.CrossFadeAlpha(1.0f, fadeDuration, false);
        starBase.CrossFadeAlpha(1.0f, fadeDuration, false);
        text.CrossFadeAlpha(1.0f, fadeDuration, false);
    }

    public void FadeOut()
    {
        bg.CrossFadeAlpha(0.0f, fadeDuration, false);
        starBase.CrossFadeAlpha(0.0f, fadeDuration, false);
        starStaticFill.CrossFadeAlpha(0.0f, fadeDuration, false);
        text.CrossFadeAlpha(0.0f, fadeDuration, false);
    }
}
