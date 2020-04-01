pipeline {
    agent any
    stages {
        
        // stage('Checkout branch') {
        //     steps {
        //         script {
        //             sh "git checkout master"
        //             sh "git pull"
        //         }
        //     }
        // }

        // stage('Construindo a imagem') {
        //     steps {
        //         script {
        //             sh "docker build -t api:v${BUILD_NUMBER} ."
        //             sh "docker tag api:v${BUILD_NUMBER} 559965085445.dkr.ecr.us-west-2.amazonaws.com/repo-api-swagger:v${BUILD_NUMBER}"
        //         }
        //     }
        // }

        stage('Publicando imagem na AWS') {
            steps {
                script {
                    withAWS(credentials: 'aws-credentials', region: 'us-west-2') {

                    sh 'aws ecr get-login-password --region us-west-2 | docker login --username AWS --password-stdin 559965085445.dkr.ecr.us-west-2.amazonaws.com/repo-api-swagger'
                        sh "docker push 559965085445.dkr.ecr.us-west-2.amazonaws.com/repo-api-swagger:v8"
                    }

                }
            }
        }        
    }
}
