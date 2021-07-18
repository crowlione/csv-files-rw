using System;
using System.Collections.Generic;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
    public static class Globals
    {
        public static String LANGUAGE {get; set;}
        public static String FILE_NAME = "Please enter the full path to your file:";
        public static String EMAIL = "Please enter your email address:";
        public static String PASSWORD = "Please enter your email password:";
        public static String RECEIVER_EMAIL = "Please enter the receiver email address:";
        public static String EMPTY_WARNING = "WARNING: The file you used is empty!\nNo new file will be generated and no email will be sent!";
        public static String FILE_NOT_FOUND = "File not found!";
        public static String EMAIL_TITLE = "File Report";
        public static String GREETING = "Hello ";
        public static String EMAIL_BODY = ", \nPlease find the requested file attached. \nWith kind regards,\nEkaterina";
        public static String FORMAT_ERROR = "Username or password not accepted! Please make sure the sender email address is either" +
            " from Gmail, mail.bg or abv.bg.";
        public static String SUCCESS = "File sent successfully!";
        public static String WRONG_RECEIVER = "Incorrect receiver email!";
        public static String INCOMPLETE_DATA = "Incomplete data! Please make sure the headers are properly named.";

        public static void changeLanguage()
        {
            FILE_NAME = "Bitte geben Sie den vollständigen Dateipfad ein:";
            EMAIL = "Bitte geben Sie Ihre E-Mail Adresse ein:";
            PASSWORD = "Bitte geben Sie Ihr E-Mail Kennwort ein:";
            RECEIVER_EMAIL = "Bitte geben Sie die Empfänger E-Mail Adresse ein:";
            EMPTY_WARNING = "WARNUNG: Die von Ihnen eingegebene Datei ist leer!\nEs wird keine neue Datei generiert und keine E-Mail gesendet!";
            FILE_NOT_FOUND = "Datei nicht gefunden!";
            EMAIL_TITLE = "Datenbericht";
            GREETING = "Sehr geehrte/r Frau/Herr ";
            EMAIL_BODY = ", \nBitte finden Sie die angeforderte Datei in dieser E-Mail angehängt. \nMit freundlichen Grüßen,\nEkaterina";
            FORMAT_ERROR = "Benutzername oder Kennwort nicht erkennt! Bitte stellen Sie sicher, dass die Absender E-Mail Adresse " +
                "von Gmail, mail.bg oder abv.bg ist.";
            SUCCESS = "Datei erfolgreich gesendet!";
            WRONG_RECEIVER = "Falsche Empfänger E-Mail Adresse!";
            INCOMPLETE_DATA = "Unvollständige Daten! Bitte stellen Sie sicher, dass die Headerzeilen richtig benannt sind.";
        }
    }
}
