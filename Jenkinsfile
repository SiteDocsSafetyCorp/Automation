pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://github.com/lorikSiteDocs/SiteDocsAutomationProject.git']]])
            }
        }
        stage('Restore packages') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --logger:"trx;LogFileName=testresults.xml"'
            }
            post {
                always {
                    junit 'testresults.xml'
                }
            }
        }
    }
}
