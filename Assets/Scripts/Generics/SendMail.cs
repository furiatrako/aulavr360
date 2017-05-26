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
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendMail : MonoBehaviour
{
    [Header("Mail settings")]
    [SerializeField]
    private string smtpServer = "smtp.twinforce.es";
    [SerializeField]
    private int port;
    [SerializeField]
    private string username;
    [SerializeField]
    private string password;
    [SerializeField]
    private bool enableSSL = false;
    [Header("Mail structure")]
    public string from;
    public string to;
    public string subject;
    public string body;
    public void Send()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(from);
        mail.To.Add(to);// "contact@twinforce.es");
        mail.Subject = subject;
        mail.Body = body;


        SmtpClient client = new SmtpClient(smtpServer);

        client.Port = port;
        client.Credentials = new System.Net.NetworkCredential(username, password) as ICredentialsByHost;
        client.EnableSsl = enableSSL;
        if (enableSSL)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
        }

        client.SendAsync(mail, "");
      //  client.Send(mail);
    }
}