## Purpose

This WEB application was developed as an entry project to the WeDoSoftware company from Novi Sad.

## Features

### 1. **User Authentication**
   - **Login**: Users can log in to the application using their email and password.
   - **Registration**: New users can create an account with a name, surname and other relevant information.

### 2. **Training Documentation**
   - Users can document their training sessions, including:
     - **Training Type**: Cardio, Powerlifting, Yoga, HIIT, CrossFit, etc.
     - **Duration**: The duration of the workout in minutes.
     - **Calories Burned**: The number of calories burned during the session.
     - **Training Difficulty**: A rating between 1-10, indicating the difficulty of the session.
     - **Tiredness**: A rating between 1-10, indicating how tired the user felt after the session.
     - **Notes**: Additional notes (optional) about the workout session.
     - **Training Date**: Date of the training session.

### 3. **Review Documented Trainings**
   - Users can view a list of all documented training sessions.
   - Each training session entry includes the details as mentioned above.

### 4. **Weekly Statistics for a Selected Month**
   - Users can view weekly statistics for a selected month, including:
     - **Total Training Time**: The total time spent on training during the selected week/month.
     - **Number of Trainings**: The total number of training sessions logged.
     - **Average Training Tiredness**: The average tiredness rating for all sessions in the selected week/month.
     - **Average Training Difficulty**: The average difficulty rating for all sessions in the selected week/month.

## Architecture

The backend of the GymTracker application is built using the **ASP.NET Framework** and follows the **Domain-Driven Design (DDD)** modular monolith structure. This approach ensures a clean, maintainable, and scalable architecture where different business domains are separated into modules, each with its own responsibilities.

Key components:
- **Modules**: Each feature (e.g., UserManagement, TrainingManagement) is organized into its own module.
- **Entities**: Core entities like `User`, `GymMember`, `Training` and `TrainingType` are designed and managed according to DDD principles.
- **Repositories**: Data is accessed and manipulated through repositories, ensuring a clean separation of concerns.
- **Services**: Business logic is encapsulated within the CQRS pattern that interacts with the modules and repositories.

## SQL Script for Inserting Entities (Test Database)

To quickly set up a test database, you can use the provided SQL script (`back_end/GymTracker.API/DevelopmentSQL/insert-dev-db.sql`) to insert sample data for `Users`, `GymMembers`, `TrainingTypes`, and `Trainings`.

## Quick setup with Docker Compose

Run docker compose to set up the Angular front end and the PostgreSQL database.

```bash
docker compose -f docker-compose.yml up -d --build
```

Apply database migrations in the back end projects.

```bash
dotnet ef database update --project GymTracker.UserManagement.Infrastructure/GymTracker.UserManagement.Infrastructure.csproj --startup-project GymTracker.API/GymTracker.API.csproj --context GymTracker.UserManagement.Infrastructure.Database.UsersContext --configuration Debug 20250115013147_Initial --connection Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=gymTracker;
```

```bash
dotnet ef database update --project GymTracker.TrainingManagement.Infrastructure/GymTracker.TrainingManagement.Infrastructure.csproj --startup-project GymTracker.API/GymTracker.API.csproj --context GymTracker.TrainingManagement.Infrastructure.Database.TrainingContext --configuration Debug 20250115012242_Initial --connection Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=gymTracker;
```

Run the ASP.NET backend manually.
