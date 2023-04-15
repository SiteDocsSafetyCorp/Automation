pipeline {
   agent any
   stages {
      stage('setup') {
         steps {
            browserstack(credentialsId: 'dw471drf-db68-4r23b-969d-24r3r32f') {
               sh 'dotnet build'
                 sh 'dotnet test --filter Category="LoginTest"'
            }
         }
      }
    }
  }
