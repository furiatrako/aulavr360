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

public class VRCamCorrection : MonoBehaviour {
    public GameObject vrPlayer;
    public Transform vrHead;
    public bool isActive = false;
    public bool IsActive
    {
        set { isActive = value; }
    }

    float correction;
    float time;

	// Use this for initialization
	void Start () {
        if (isActive)
        {
            vrHead.parent.GetComponent<GvrViewer>().Recenter();
            if (PlayerPrefs.GetInt("_CAL_ok", 0) == 1)
            {
                GetData();
            }
            if (time != 0)
            {
                StartCorrection();
            }
        }
	}

    private void GetData()
    {
        correction = PlayerPrefs.GetFloat("_CAL_corrAmount");
        time = PlayerPrefs.GetFloat("_CAL_corrTime");
    }

    private void StartCorrection()
    {
        StartCoroutine(Correct());
    }

    IEnumerator Correct()
    {
        Vector3 currentRotation;
        while (true)
        {
            currentRotation = vrPlayer.transform.localRotation.eulerAngles;
            vrPlayer.transform.Rotate(Vector3.up * (float)correction, Space.Self);
            yield return new WaitForSeconds(time);
        }
    }

    public void Stop()
    {
        StopCoroutine(Correct());
    }
}
