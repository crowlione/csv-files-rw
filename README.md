# csv-files-rw
C# (.net Core) console application assessment task.

## Installation

The project uses [CsvHelper](https://joshclose.github.io/CsvHelper/) to read/write to the csv files. It can be installed with the Visual Studio Package Manager Console:

*PM> Install-Package CsvHelper*

The emails are sent using [MailKit](https://github.com/jstedfast/MailKit). It can be installed with the Visual Studio Package Manager Console:

*PM> Install-Package MailKit*

## Mail Service

E-mails can be sent either with the gmail.com, abv.bg or mail.bg service. Please have in mind that using a Gmail account as a sender requires having allowed third-party apps.

## CSV Delimiter

The delimiter in the newly generated file will by default be ';'.



