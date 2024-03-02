pipeline {
    agent any

    environment {
        DOCKER_IMAGE_NAME = 'buber-dinner'
    }

    stages {
        stage('Build') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                }
            }
            steps {
                // Checkout your source code from version control
                checkout scm
                
                // Build ASP.NET application (replace with your build command)
                sh 'dotnet build'
            }
        }
        stage('Build Docker Image') {
            agent {
                docker {
                    image 'docker'
                }
            }
            steps {
                // Build Docker image for ASP.NET application
                script {
                    sh 'docker build -t $DOCKER_IMAGE_NAME .'
                }
            }
        }
        stage('Deploy') {
             agent {
                docker {
                    image 'docker'
                }
            }
            steps {
                // Use Docker Compose to run the application
                script {
                    sh "docker-compose -f docker-compose.yml up -d"
                }
            }
        }
    }

    post {
        always {
            echo 'After CI'
        }
    }
}
