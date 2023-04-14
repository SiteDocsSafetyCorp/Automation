 pipeline {
   agent any
   stages {
       stage('setup') {
         steps {
             browserstack(credentialsId: '28f04091-7d5e-4db3-92f6-ec76a46d263e') {
                 // add commands to run test
                 // Following are some of the example commands -----
                 sh 'dotnet build'
                 sh 'dotnet test --filter Category="LoginTest"'
             }
         }
         # ...
       }
     }
   }
