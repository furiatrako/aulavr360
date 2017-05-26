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

public class Questionary : MonoBehaviour {

    public static string[,] questions = new string[,]
    {
        {"","","","" },
        {"Ets el seleccionador, que vols fer ara?",
            "Deixar que la entrevistada parli del que li sembli més convenient per crear un bon clima.",
            "Fer-li preguntes sobre aspectes tècnics.",
            "Fer-li preguntes sobre la seva experiència prèvia en llocs similars"},
        {"Com vols que continuï aquesta entrevista?",
            "Fer-li preguntes sobre aspectes tècnics.",
            "Fer-li preguntes sobre la seva experiència prèvia en llocs similars.",
            ""},
         {"Com vols que continuï aquesta entrevista?",
            "Deixem que ens pregunti per l’entrevista.",
            "Acabem la entrevista.",
            "Continuem preguntant-li per l’anterior feina."},
         {"Selecciona una opció.",
            "Deixem que ens pregunti per l’entrevista.",
            "Acabarem l'entrevista.",
         "Fer-li preguntes sobre aspectes tècnics."},
         {"Arribem al final.",
            "Continuar",
            "",
            ""},
         {"","","",""},
         {"Com és lògic suposar, qui t'entrevista normalment sol ser algú que habitualment fa aquest tipus de treball, com a expert en el maneig d'aquests processos. Doncs bé, per obtenir el màxim rendiment en l'obtenció de la informació que es busca en una entrevista de selecció, existeixen determinades regles que normalment es tenen en compte  . Així els entrevistadors solen preguntar amb finalitats d'ampliar la informació, sobre els estudis, experiències i interessos i, sobretot , per aquelles qualitats que puguin ajudar a predir l'adaptació  del candidat al lloc de treball  . Un bon entrevistador:"
            + "\n1. No fa preguntes que tinguin una resposta òbvia."
            + "\n2. No fer preguntes teòriques."
            + "\n3. Aprofundir suficientment."
            + "\n\n No oblidis que els entrevistadors són experts en aquests processos i, per tant, sabedors de quins són els aspectes que busquen els candidats a un lloc de treball.","","",""},
         {"En quant a Esther com valoraries la entrevista: et sembla que el seu punt fort és la seva capacitat tècnica o la seva capacitat per a relacionar-se amb els altres i aportar iniciativa a l’equip?","","",""},
         {"Es adir és millor en el seu domini del paquet d’Office, els Idiomes i els Coneixements de Comptabilitat o En el seu control de les competències personals com la Sociabilitat, el Control emocional, la seva Iniciativa o la forma d’autogestionar-se del temps?",
            "A) PERFIL TÈCNIC",
            "B) PERFIL RELACIONAL",
            "C) LES DUES PER IGUAL" },
         {"I en quant al entrevistador que creus que valorarà com més important per aquest lloc de feina?"
            +"\n Reflexiona les teves respostes amb el tècnic d’orientació de l’ajuntament de Cerdanyola.",
            "A) PERFIL TÈCNIC",
            "B) PERFIL RELACIONAL",
            "C) LES DUES PER IGUAL" },
         {"Moltes gràcies per completar aquesta sessió, Quan seleccionis CONTINUAR la sessió acabarà i sortiràs del mode de Realitat Virtual.","","",""},
    };
}
