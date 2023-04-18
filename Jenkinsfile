pipeline {
   agent any
   stages {
      stage('setup') {
         steps {
            browserstack(credentialsId: 'dw471drf-db68-4r23b-969d-24r3r32f') {
               bat 'dotnet build'
               bat 'dotnet build'
                 bat ' dotnet test C:\Users\Lorik\Desktop\automation\SiteDocsAutomationProject\bin\Debug\net6.0\SiteDocsAutomationProject.dll'
            }
         }
      }
    }
  }
