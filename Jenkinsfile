pipeline {
    agent any
    stages {
        
        stage('Checkout branch') {
            steps {
                script {
                    sh "git checkout master"
                    sh "git pull"
                }
            }
        }

        stage('Criar task AWS') {
            steps {
                script {
                    try {
                        sh "aws ecs register-task-definition --cli-input-json file://task_repo.json"

                        sh "git pull"
                    } catch (Exception e) {
                    }
                }
            }
        }

        stage('SonarQube analysis') {
            environment {
                scannerHome = tool 'SonarQubeScanner'
            }
             steps {
                 withSonarQubeEnv('sonarqube') {
                    sh "${scannerHome}/bin/sonar-scanner"
                }
                timeout(time: 10, unit: 'MINUTES') {
                    waitForQualityGate abortPipeline: true
                }
                // script {
                //     withSonarQubeEnv('sonarqube') {
				//         sh 'mvn sonar:sonar -Dsonar.projectKey=projeto-jenkins-sonarqube -Dsonar.host.url=http://127.0.0.1:9000 -Dsonar.login=c791bb8fc9fc394f2e8659381a841921a8a6b6ba'
			    //     }
                // }
            }			

		}
    }
}
