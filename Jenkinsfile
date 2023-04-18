pipeline {
    agent any
    stages {
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
            environment {
                BROWSERSTACK_USERNAME = credentials('lorikhalili_uERdax')
                BROWSERSTACK_ACCESS_KEY = credentials('kfByopMkLwsLKeG4fz5j')
            }
            steps {
                sh 'dotnet test --filter "TestCategory=LoginTest"'
            }
            post {
                always {
                    publishHTML([allowMissing: false, alwaysLinkToLastBuild: true, keepAll: true, reportDir: 'TestResults', reportFiles: 'index.html', reportName: 'BrowserStack Test Report'])
                }
            }
        }
    }
}
