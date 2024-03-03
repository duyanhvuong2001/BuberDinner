pipeline {
    agent any

    environment {
        DOCKER_IMAGE_NAME = 'buber-dinner'
    }

    stages {
        stage('Build') {
            steps {
                script {
                    // Build Docker Image
                    docker.build('buber-dinner:latest', '-f Dockerfile .')
                }
            }
        }
        
        stage('Deploy') {
            agent any
            steps {
                // Use Docker Compose to run the application
                script {
                    sh "docker compose up-d"
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
