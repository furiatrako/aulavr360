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

public class VRCamCalibrate : MonoBehaviour {
    public bool auto = false;
    public float calibrationTime = 1;
    [Tooltip("Time interval between correction translations")]
    public float correctionTime = 0.05f;
    public Transform vrHead;
    public GameObject vrPlayer;
    public Slider FineCorrectionSlider;
    public GameObject controls;

    [Header("Feedback")]
    public Text stateTxt;


    private double initialY;
    private double finalY;

    private double correctionY;


    private void Start()
    {
        stateTxt.text = "COMENÇANT CALIBRAT";
        vrHead.parent.GetComponent<GvrViewer>().Recenter();
        //if (auto) Invoke("StartCalibration", 1) ;
    }

    public void StartCalibration()
    {
        
        stateTxt.text = "CALIBRANT";
        initialY = vrHead.localRotation.eulerAngles.y;
        StartCoroutine(StopCalibrate());
    }

    private void StopCalibration()
    {
        stateTxt.text = "CALIBRAT FINALITZAT";
        finalY = vrHead.localRotation.eulerAngles.y;
        CalculateCorrection();
    }

    private void CalculateCorrection()
    {
        double delta;
        double deltaBaseOne;

        initialY = (initialY > 180) ? (initialY - 360) : initialY;
        finalY = (finalY > 180) ? (finalY - 360) : finalY;
        delta = finalY - initialY;
            Debug.Log("Delta "+delta );
            deltaBaseOne = delta / calibrationTime;
            correctionY = -deltaBaseOne * correctionTime * FineCorrectionSlider.value;
        

       
        SaveData();
        if (auto) StartCorrection();
    }

    public void Recalculate()
    {
        auto = false;
        CalculateCorrection();
    }

    public void StartCorrection()
    {
        controls.SetActive(true);
        stateTxt.text = "CORRECIÓ FINAL";
        StartCoroutine(Correct());
    }

    IEnumerator Correct()
    {
        Vector3 currentRotation;
        while (true)
        {
           // Debug.Log("Fine calibration " +correctionY);
            currentRotation = vrPlayer.transform.localRotation.eulerAngles;
            vrPlayer.transform.Rotate(Vector3.up * (float)correctionY, Space.Self);
            yield return new WaitForSeconds(correctionTime);
        }
    }

    IEnumerator StopCalibrate()
    {
        yield return new WaitForSeconds(calibrationTime);
        stateTxt.text = "CALIBRAT FINALITZAT";
        finalY = vrHead.localRotation.eulerAngles.y;
        CalculateCorrection();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("_CAL_ok", 1);
        PlayerPrefs.SetFloat("_CAL_corrAmount", (float)correctionY);
        PlayerPrefs.SetFloat("_CAL_corrTime", (float)correctionTime);
    }

    public void Stop() {
        StopAllCoroutines();
    }
}
