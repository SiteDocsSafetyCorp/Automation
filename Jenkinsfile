pipeline {
   agent any
   tools {nodejs "node"}

   stages {
      stage('setup') {
         steps {
            browserstack(credentialsId: 'e4869b41-3f31-438b-9c4b-a6d72748378f') {
               // some example test commands ...
               sh 'dotnet restore'
               sh 'dotnet build'
                sh 'dotnet test --filter=LoginTest'
            }
             // Enable reporting in Jenkins
             browserStackReportPublisher 'automate'
         }
      }
    }
  }
