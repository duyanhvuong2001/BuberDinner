pipeline {
    agent any

    environment {
        DOCKER_IMAGE_NAME = 'my-aspnet-app'
        DOCKER_COMPOSE_VERSION = '1.29.2'
    }

    stages {
        stage('Build') {
            steps {
                // Checkout your source code from version control
                checkout scm
                
                // Build ASP.NET application (replace with your build command)
                sh 'dotnet build'
            }
        }
        stage('Build Docker Image') {
            steps {
                // Build Docker image for ASP.NET application
                script {
                    sh 'docker build -t $DOCKER_IMAGE_NAME .'
                }
            }
        }
        stage('Run Tests') {
            steps {
                // Run tests if applicable
                // Example: sh 'dotnet test'
            }
        }
        stage('Deploy') {
            steps {
                // Use Docker Compose to run the application
                script {
                    sh "docker-compose -f docker-compose.yml up -d"
                }
            }
        }
    }

    post {
        
    }
}
