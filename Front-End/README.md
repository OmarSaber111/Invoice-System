# Front-End for Invoice Project (Angular 17)

This repository contains the **front-end** of the Invoice application, built with **Angular 17** and styled using **Bootstrap**.

## Prerequisites

Before running the project, make sure you have the following installed:

- **Node.js** (LTS version): [Download here](https://nodejs.org/)
- **Angular CLI**: [Install with `npm install -g @angular/cli`](https://angular.io/cli)

Additionally, you need **Bootstrap 5** for styling, which will be included via npm.

## Getting Started

### 1. Clone the repository

Clone the entire repository (including the back-end folder) into your local machine:

```bash
git clone https://github.com/your-username/your-repo-name.git
```

### 2. Navigate to the Front-End folder

```bash
cd your-repo-name/front-end
```

### 3. Install Dependencies

Run the following command to install all the required dependencies (including Angular and Bootstrap):

```bash
npm install
```

This will install:
- Angular 17
- Bootstrap (which is already included in the `angular.json` file)

### 4. Configure with the Backend

The API for this project is hosted at **[Invoice API](http://invoice.somee.com/swagger/index.html)**. To connect the front-end with the back-end, you need to make sure the following configurations are set:

- **API URL**: Update the `src/environments/environment.ts` (or `environment.prod.ts` for production) file with the base API URL.

```ts
export const environment = {
  production: false,
  apiUrl: 'http://invoice.somee.com/api', // Base URL for the API
};
```

### 5. Running the Project

To run the Angular project in development mode, simply execute:

```bash
ng serve
```

- This will start the application on `http://localhost:4200/`.
- Any changes you make will be automatically reflected in the browser.

### 6. Open the Application in Your Browser

Once the development server is running, open your browser and go to:

```
http://localhost:4200
```

---

## Using Swagger UI to Interact with the API

You can interact with the back-end API via **Swagger UI** hosted at:

[http://invoice.somee.com/swagger/index.html](http://invoice.somee.com/swagger/index.html)

This will allow you to test the API endpoints and see the structure of the requests and responses.

---

## Folder Structure

- `src/app/` – Contains the Angular components, services, and modules.
- `src/assets/` – Static assets like images, icons, etc.
- `src/environments/` – Configuration for different environments (`environment.ts` for development).
- `node_modules/` – Contains all the npm dependencies (do not modify directly).

---

## Further Customizations

- You can customize the API service and integrate with other back-end endpoints by modifying the service files inside `src/app/services/`.
- For styling and layout, you can update Bootstrap classes in the component HTML files.

---
