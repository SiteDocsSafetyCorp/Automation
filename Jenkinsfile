pipeline {
   agent any
   stages {
      stage('setup') {
         steps {
            browserstack(credentialsId: '28f04091-7d5e-4db3-92f6-ec76a46d263e') {
               echo "hello"
            }
         }
      }
    }
  }
