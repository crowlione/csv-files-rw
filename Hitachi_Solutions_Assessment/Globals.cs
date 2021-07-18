using System;
using System.Collections.Generic;
using System.Text;

namespace Hitachi_Solutions_Assessment
{
    public static class Globals
    {
        public static String LANGUAGE {get; set;}
        public static String FILE_NAME = "Please enter the full path to your file:\n";
        public static String EMAIL = "Please enter your email address:\n";
        public static String PASSWORD = "Please enter your email password:\n";
        public static String RECEIVER_EMAIL = "Please enter the receiver email address:\n";
        public static String EMPTY_WARNING = "WARNING: The file you used is empty!\nNo new file will be generated and no email will be sent!";
        public static String FILE_NOT_FOUND = "File not found!";
        public static String EMAIL_TITLE = "File Report";
        public static String GREETING = "Hello ";
        public static String EMAIL_BODY = ", \nPlease find the requested file attached. \nWith kind regards,\nEkaterina";
        public static String FORMAT_ERROR = "Wrong email format!";
        public static String UNAUTHORIZED_ERROR = "The SMTP server requires a secure connection or the client was not authenticated (wrong password).";

        public static void changeLanguage()
        {
            FILE_NAME = "Bitte geben Sie den vollständigen Dateipfad ein:\n";
            EMAIL = "Bitte geben Sie Ihre E-Mail Adresse ein:\n";
            PASSWORD = "Bitte geben Sie Ihr E-Mail Kennwort ein:\n";
            RECEIVER_EMAIL = "Bitte geben Sie die Empfänger E-Mail Adresse ein:\n";
            EMPTY_WARNING = "WARNUNG: Die von Ihnen eingegebene Datei ist leer!\nEs wird keine neue Datei generiert und keine E-Mail gesendet!";
            FILE_NOT_FOUND = "Datei nicht gefunden!";
            EMAIL_TITLE = "Datenbericht";
            GREETING = "Sehr geehrte/r Frau/Herr ";
            EMAIL_BODY = ", \nBitte finden Sie die angeforderte Datei in dieser E-Mail angehängt. \nMit freundlichen Grüßen,\nEkaterina";
            FORMAT_ERROR = "Falsches E-Mail Format!";
            UNAUTHORIZED_ERROR = "Der SMTP-Server erfordert eine sichere Verbindung oder der Benutzer wurde nicht authentifiziert (falsches Kennwort).";
        }
    }
}
