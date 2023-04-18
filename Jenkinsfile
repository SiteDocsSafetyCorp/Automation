pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                browserstack(credentialsId: 'e4869b41-3f31-438b-9c4b-a6d72748378f', buildName: 'My Jenkins Build', projectName: 'My Jenkins Project', debug: 'false') {
                    sh 'dotnet test --logger:"trx;LogFileName=testresults.xml"'
                }
                junit 'testresults.xml'
            }
        }
    }
}
