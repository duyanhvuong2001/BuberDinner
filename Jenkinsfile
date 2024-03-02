pipeline {
    agent any
    
    stages {
        stage('Build') {
            agent {
                docker {
                    image 'docker/compose'
                }
            }
            steps {
                // This stage simulates a build step, you can replace this with your actual build commands
                echo 'Building...'
                sh 'docker-compose up --build'
            }
        }
        stage('Test') {
            steps {
                // This stage simulates a test step, you can replace this with your actual test commands
                echo 'Testing...'
            }
        }
        stage('Deploy') {
            steps {
                // This stage simulates a deployment step, you can replace this with your actual deployment commands
                echo 'Deploying...'
            }
        }
    }
    
    post {
        success {
            // This block will be executed if the pipeline succeeds
            echo 'Pipeline succeeded!'
        }
        failure {
            // This block will be executed if the pipeline fails
            echo 'Pipeline failed!'
        }
    }
}