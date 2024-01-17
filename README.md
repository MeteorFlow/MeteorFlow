# MeteorFlow

This repository contains a project named "MeteorFlow" and provides a set of npm scripts to help manage common tasks in both Unix-like and Windows environments. These scripts include checking the environment, restoring project dependencies, building, and running development tasks.

## Getting Started

Before you begin, ensure you have the following prerequisites installed:

- Node.js (v16 or higher)
- .NET SDK (v7 or higher)
- Docker

## Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/QuynhNhu14/MeteorFlow.git
   ```

2. Navigate to the project directory:

   ```bash
   cd MeteorFlow
   ```

3. To check if your environment meets the required .NET and Node.js versions, run:

  ```bash
  npm run check-env
  ```

4. To restore project dependencies (e.g., NuGet packages for .NET and npm packages for Node.js), run:

```bash
npm run restore
```  

## Usage

### Building the Project

To build the project (both .NET and Node.js), run:

```bash
npm run build
```

### Managing Docker Containers
To manage Docker containers for the project, you can use the following commands:

To start Docker containers:

```bash
npm run db:up
```

To stop Docker containers:

```bash
npm run db:down
```

### Running Development Tasks

To run development tasks (e.g., starting a development server), run:

```bash
npm run dev
```

### Platform-Specific Commands

You can also run these commands specifically for Unix-like systems or Windows by prefixing them with `unix:` or `win:` respectively. For example:

- To check the environment on Unix:

  ```bash
  npm run unix:check-env
  ```

- To check the environment on Windows:

  ```bash
  npm run win:check-env
  ```

- Similar commands can be used for restoring, building, and running development tasks.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

