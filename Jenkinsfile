
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                dotnetCoreBuild(path: 'SiteDocsAutomationProject.csproj')
            }
        }
        stage('Test') {
            steps {
                sh 'echo "Starting tests..."'
                script {
                    def nunitCmd = "dotnet test SiteDocsAutomationProject.csproj --filter 'TestCategory=LoginTest'"
                    def nunitResults = sh(script: nunitCmd, returnStdout: true)
                    writeFile file: 'nunit-results.xml', text: nunitResults
                }
                junit 'nunit-results.xml'
            }
        }
        stage('Publish') {
            steps {
                sh 'echo "Publishing results..."'
                archiveArtifacts artifacts: '**/bin/*.dll'
            }
        }
    }
}
