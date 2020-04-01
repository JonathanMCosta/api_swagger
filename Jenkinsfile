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
                    docker.withRegistry('https://559965085445.dkr.ecr.us-west-2.amazonaws.com', 'ecr:us-west-2:jenkins') {
                        sh "docker push 559965085445.dkr.ecr.us-west-2.amazonaws.com/repo-api-swagger:v8"
                    }
                }
            }
        }        
    }
}
