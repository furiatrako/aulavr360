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
using UnityEngine.SceneManagement;

public class LoadRoom : MonoBehaviour {
    public Material extMaterial;
    public Material intMaterial;
    public MenuController mController;

    AsyncOperation async;

    public void GoToRoom()
    {
        mController.ShowLoading();
        ////////////
        async = SceneManager.LoadSceneAsync("RoomScene");
        async.allowSceneActivation = false;
        ////////////


        Invoke("LoadRoomScene", 5f);
    }

    private void LoadRoomScene()
    {
        //SceneManager.LoadSceneAsync("RoomScene");
        async.allowSceneActivation = true;
    }
}
