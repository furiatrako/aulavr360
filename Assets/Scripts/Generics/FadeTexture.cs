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

using UnityEngine;
using System.Collections;

public class FadeTexture : MonoBehaviour {
    public Renderer rend;
    private Material mat;
    public float speed = 20f;
    private bool isFade = false;
    public bool IsFade
    {
        get { return isFade; }
    }
    private float target;
    
	// Use this for initialization
	void Start () {
        if (rend != null) mat = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFade)
        {
            Fade(target);
        }
	}

    public void FadeIn()
    {
        target = 1;
        isFade = true;
    }

    public void FadeOut()
    {
        target = 0;
        isFade = true;
    }

    private void Fade(float targetValue)
    {
        if (mat != null)
        {
            Color currentColor = mat.color;
            float alpha = currentColor.a;
            if ((alpha + 0.1f) >= target)
            {
                isFade = false;
                alpha = target;
            }
            alpha = Mathf.Lerp(alpha, targetValue, Time.deltaTime * speed);
            currentColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            mat.color = currentColor;
            
        }
        
    }
}
