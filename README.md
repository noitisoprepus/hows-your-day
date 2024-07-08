# HowsYourDay

This web application is designed to help users share their daily experiences. This repository contains the source code for the application, including the backend API, frontend client, and PostgreSQL database.

## Prerequisites
- Docker
- Docker Compose

## Getting Started

### Step 1: Clone the Repository
Clone the repository to your local machine using the following command:
```sh
git clone https://github.com/noitisoprepus/hows-your-day.git
cd hows-your-day
```

### Step 2: Create a `.env` File
Create a `.env` file in the root directory of the project with the following keys:
```plaintext
POSTGRES_DB=howsyourdaydb
POSTGRES_USER=howsyourday
POSTGRES_PASSWORD=your_secure_password
JWT_ISSUER=howsyourday
JWT_AUDIENCE=howsyourday
JWT_KEY=your_jwt_key
```
Replace `your_secure_password` and `your_jwt_key` with your desired values.

### Step 3: Build and Run the Application
Build and run the application using Docker Compose:
```sh
docker-compose up --build
```

### Step 4: Access the Application
Once the containers are up and running, you can access the application:
- Backend API: [http://localhost:5000](http://localhost:5000)
- Frontend Client: [http://localhost:8080](http://localhost:8080)

## License
This project is licensed under the MIT License. See the [LICENSE](https://github.com/noitisoprepus/hows-your-day/blob/main/LICENSE) file for details.
