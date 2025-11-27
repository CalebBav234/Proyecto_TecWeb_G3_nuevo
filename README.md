# E-Learning API

This is an ASP.NET Core Web API for an e-learning platform, providing endpoints for authentication, student management, and lesson management.

## What is this project?

This API models a simple e-learning platform called **Educocha**.

The idea is to simulate a real scenario where:

- Users register and log in.
- An **Admin** manages:
  - **Students** (student profiles linked to users)
  - **Courses** and their **Lessons**
  - **Enrollments** (which student is assigned to which course)
  - **Certificates** for students
- Authenticated users can access data according to their role.

We chose this domain because online courses are a common real-world service (similar to Udemy/Coursera) and it lets us practice:

- 1–N, N–M and 1–1 relationships in the database.
- Authentication with JWT and authorization with roles.
- A more realistic flow than a single CRUD.

---

## Installation

### Prerequisites
- Docker
- Docker Compose

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/CalebBav234/Proyecto_TecWeb_G3_nuevo.git
   cd Proyecto_TecWeb_G3_nuevo/elearning2
Run the application using Docker Compose:

bash
Copiar código
docker-compose up --build
The API will be available at http://localhost:5052.

Endpoints
Authentication
POST /api/v1/auth/register

Description: Registers a new user.

Authorization: None

Request Body:

email (string): User email

password (string): User password

role (string): Admin or User

Body example:

json
Copiar código
{
  "email": "user@example.com",
  "password": "MyStrongPass123!",
  "role": "User"
}
POST /api/v1/auth/login

Description: Logs in a user and returns a token.

Authorization: None

Request Body:

email (string): User email

password (string): User password

Body example:

json
Copiar código
{
  "email": "user@example.com",
  "password": "MyStrongPass123!"
}
POST /api/v1/auth/refresh

Description: Refreshes the authentication token.

Authorization: None

Students
GET /api/v1/student

Description: Retrieves all students with pagination.

Authorization: Admin only

GET /api/v1/student/{id}

Description: Retrieves a specific student by ID.

Authorization: Any authenticated user

GET /api/v1/student/user/{userId}

Description: Retrieves a student by user ID.

Authorization: Admin only

GET /api/v1/student/search?fullName={name}

Description: Searches for a student by full name.

Authorization: Any authenticated user

POST /api/v1/student

Description: Creates a new student.

Authorization: Admin only

Request Body:

UserId (GUID): Linked user ID

FullName (string): Full name

Bio (string): Short bio

AvatarUrl (string): Avatar image URL

Body example:

json
Copiar código
{
  "userId": "2c0fbd5a-6b4b-4b83-9b9b-123456789abc",
  "fullName": "John Doe",
  "bio": "Backend developer",
  "avatarUrl": "https://example.com/avatar.jpg"
}
PUT /api/v1/student/{id}

Description: Updates an existing student.

Authorization: Admin only

Request Body:

FullName (string): Updated full name

Bio (string): Updated bio

AvatarUrl (string): Updated avatar URL

Body example:

json
Copiar código
{
  "fullName": "John Doe Updated",
  "bio": "Full stack developer",
  "avatarUrl": "https://example.com/new-avatar.jpg"
}
DELETE /api/v1/student/{id}

Description: Deletes a student.

Authorization: Admin only

Lessons
GET /api/v1/lesson

Description: Retrieves all lessons with pagination.

Authorization: Any authenticated user

GET /api/v1/lesson/{id}

Description: Retrieves a specific lesson by ID.

Authorization: Any authenticated user

GET /api/v1/lesson/course/{courseId}

Description: Retrieves lessons by course ID with pagination.

Authorization: Any authenticated user

GET /api/v1/lesson/search?title={title}

Description: Searches for a lesson by title.

Authorization: Any authenticated user

POST /api/v1/lesson

Description: Creates a new lesson.

Authorization: Admin only

Request Body:

CourseId (GUID): Course owner of the lesson

Title (string): Lesson title

Content (string): Lesson content

Body example:

json
Copiar código
{
  "courseId": "54f1fd3c-2ac0-4ee4-8f76-123456789abc",
  "title": "Introduction to REST APIs",
  "content": "Lesson content goes here..."
}
PUT /api/v1/lesson/{id}

Description: Updates an existing lesson.

Authorization: Admin only

Request Body:

Title (string): Updated title

Content (string): Updated content

Body example:

json
Copiar código
{
  "title": "REST APIs – Updated",
  "content": "Updated lesson content..."
}
DELETE /api/v1/lesson/{id}

Description: Deletes a lesson.

Authorization: Admin only

Certificates
GET /api/v1/certificate

Description: Retrieves all certificates with pagination.

Authorization: Any authenticated user

Query Parameters:

page (int, optional): Page number (default 1)

limit (int, optional): Number of certificates per page (default 10)

GET /api/v1/certificate/{id}

Description: Retrieves a specific certificate by its unique ID (GUID).

Authorization: Any authenticated user

GET /api/v1/certificate/student/{studentId}

Description: Retrieves all certificates associated with a specific student by their student ID.

Authorization: Any authenticated user

GET /api/v1/certificate/title?title={title}

Description: Retrieves a specific certificate by its title.

Authorization: Any authenticated user

Query Parameters:

title (string, required): The title of the certificate to search for

POST /api/v1/certificate

Description: Creates a new certificate entry.

Authorization: Admin only

Request Body:

StudentId (GUID): ID of the student the certificate belongs to

Title (string): Title of the certificate

Description (string): Description of the certificate

Body example:

json
Copiar código
{
  "studentId": "5e62a0a4-2be1-4a79-8bcb-123456789abc",
  "title": "ASP.NET Core Fundamentals",
  "description": "Certificate for completing the ASP.NET Core course."
}
PUT /api/v1/certificate/{id}

Description: Updates an existing certificate by its ID. Fields can be selectively updated.

Authorization: Admin only

Request Body:

StudentId (GUID, optional): Updated student ID

Title (string, optional): Updated title

Description (string, optional): Updated description

Body example:

json
Copiar código
{
  "studentId": "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
  "title": "ASP.NET Core Advanced",
  "description": "Updated description for the certificate."
}
DELETE /api/v1/certificate/{id}

Description: Deletes a certificate by its ID.

Authorization: Admin only

Enrollments
GET /api/v1/enrollment

Description: Retrieves all enrollments with pagination.

Authorization: Admin only

Query Parameters:

page (int, optional): Page number (default 1)

limit (int, optional): Number of enrollments per page (default 10)

GET /api/v1/enrollment/{id}

Description: Retrieves a specific enrollment by its ID.

Authorization: Any authenticated user

GET /api/v1/enrollment/student/{studentId}

Description: Retrieves all enrollments for a specific student.

Authorization: Any authenticated user

GET /api/v1/enrollment/course/{courseId}

Description: Retrieves all enrollments for a specific course.

Authorization: Any authenticated user

POST /api/v1/enrollment

Description: Creates a new enrollment (assigns a student to a course).

Authorization: Admin only

Request Body:

StudentId (GUID): ID of the student to enroll

CourseId (GUID): ID of the course

Body example:

json
Copiar código
{
  "studentId": "5e62a0a4-2be1-4a79-8bcb-123456789abc",
  "courseId": "54f1fd3c-2ac0-4ee4-8f76-123456789abc"
}
PUT /api/v1/enrollment/{id}

Description: Updates an existing enrollment.

Authorization: Admin only

Request Body:

StudentId (GUID, optional): New student ID (if changed)

CourseId (GUID, optional): New course ID (if changed)

Body example:

json
Copiar código
{
  "studentId": "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
  "courseId": "ffffffff-1111-2222-3333-444444444444"
}
DELETE /api/v1/enrollment/{id}

Description: Deletes an enrollment by its ID.

Authorization: Admin only

ER diagram (summary)
Main entities and fields:

Student

Id (GUID, PK)

UserId (GUID)

FullName (string)

Bio (string)

AvatarUrl (string)

Course

Id (GUID, PK)

StudentId (GUID, FK – course author)

Title (string)

Description (string)

CreatedAt (datetime)

Lesson

Id (GUID, PK)

CourseId (GUID, FK)

Title (string)

Content (string)

CreatedAt (datetime)

Enrollment

Id (GUID, PK)

StudentId (GUID, FK)

CourseId (GUID, FK)

EnrolledAt (datetime)

Certificate

Id (GUID, PK)

StudentId (GUID, FK)

Title (string)

Description (string)

If you add the ER image to the repo, you can reference it like:

markdown
Copiar código
![ER Diagram](docs/er-diagram.png)
Authentication, authorization and roles
The API uses JWT tokens for authentication.

After calling /api/v1/auth/login, the response includes a token.

The token must be sent in the Authorization header:

http
Copiar código
Authorization: Bearer <token>
Roles:

Admin

User

Authorization attributes in controllers:

Endpoints for admins only:

csharp
Copiar código
[Authorize(Policy = "AdminOnly")]
Endpoints for any authenticated user:

csharp
Copiar código
[Authorize]
In general:

Admin can create, update and delete Students, Lessons, Certificates and Enrollments.

User can access read-only endpoints (GET) for lessons, certificates, enrollments, etc.

Swagger and Postman
Swagger UI is available at: http://localhost:5052/swagger
It documents all endpoints and allows testing them directly in the browser, including sending the JWT token.

The repository also includes a Postman collection (JSON) with:

Auth requests (register, login, refresh)

CRUD operations for Students, Lessons, Certificates and Enrollments

Environment variables for base URL and token
