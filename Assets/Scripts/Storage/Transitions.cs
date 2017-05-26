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

public class Transitions  {

    public static int[,] cutscenes = new int[,]
    {
        { 1,-1,-1},//INTRO (DEPRECATED)
        { 2, 3, 4},//Scene 1
        { 3, 4,-1},//Scene 2
        { 5, 6, 4},//Scene 3
        { 5, 6, 3},//Scene 4
        { 6,-1,-1},//Scene 5
        {-1,-1,-1},//Scene 6
        {-1,-1,-1},//Consideration
        {-1,-1,-1},//Survey 1
        { 0, 1, 2},//Survey 2
        { 0, 1, 2},//Survey 3
        {-1,-1,-1},//End

    };
}
