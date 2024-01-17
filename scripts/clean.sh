#!/bin/bash

# Define the root directory
root_dir="$(dirname "$(dirname "$(readlink -f "$0")")")"

# Navigate to the src/ directory
cd "$root_dir/src"

# Function to clean packages for a .NET project
clean_dotnet_project() {
  local project_dir="$1"
  # Navigate to the project directory
  cd "$project_dir"

  # Check if it's a .NET project (contains a .csproj file)
  if [ -f *.csproj ]; then
    # Run dotnet clean to remove build artifacts
    echo "Cleaning .NET project in $project_dir"
    dotnet clean

    # Remove bin and obj directories
    rm -rf bin obj
  fi

  # Navigate back to the src/ directory
  cd ..
}

# Iterate over each directory in src/
for project_dir in */; do
  if [ -e "$project_dir" ]; then
    # Check if it's a directory
    if [ -d "$project_dir" ]; then
      clean_dotnet_project "$project_dir"
    fi
  fi
done

# Check if it's a directory
if [ -d "$root_dir/src/MeteorFlow.Web" ]; then
  # Navigate to the MeteorFlow.Web directory
  cd "$root_dir/src/MeteorFlow.Web"

  # Run npm ci to clean npm packages
  echo "Cleaning npm packages in MeteorFlow.Web"
  npm ci
fi

# Return to the original directory
cd "$root_dir"

# Stop and remove Docker containers
echo "Stopping and removing SQL Server Docker containers"
docker-compose down
