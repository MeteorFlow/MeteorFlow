#!/bin/bash

# Define the root directory
root_dir="$(dirname "$(dirname "$(readlink -f "$0")")")"

# Navigate to the src/MeteorFlow.Web directory
cd "$root_dir/src/MeteorFlow.Web"

# Build the Vite React-TS project
echo "Building Vite React-TS project..."
npm run build

# Navigate back to the root directory
cd "$root_dir"

# Build the .NET solutions in the src/ directory
echo "Building .NET solutions..."
dotnet build "$root_dir/src/MeteorFlow.sln"
