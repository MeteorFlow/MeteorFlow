#!/bin/bash

# Define the root directory
root_dir="$(dirname "$(dirname "$(readlink -f "$0")")")"

# Navigate to the src/ directory
cd "$root_dir/src"

# Iterate over each directory in src/
for project_dir in */; do
  if [ -e "$project_dir" ]; then
    # Check if it's a directory
    if [ -d "$project_dir" ]; then
      # Navigate to the project directory
      cd "$project_dir"

      # Check if it's a .NET project (contains a .csproj file)
      if [ -f *.csproj ]; then
        # Run dotnet restore
        echo "Restoring .NET project in $project_dir"
        dotnet restore
      fi

      # Navigate back to the src/ directory
      cd ..
    fi
  fi
done

# Check if it's a directory
if [ -d "MeteorFlow.Web" ]; then
  # Navigate to the MeteorFlow.Web directory
  cd "$root_dir/src/MeteorFlow.Web"
  # Run npm ci
  echo "Running 'npm ci' in MeteorFlow.Web"
  npm ci
fi

# Return to the original directory
cd "$root_dir"

# Start Docker containers
echo "Retrieving SQL Server Docker Image"
docker-compose up -d