#!/bin/bash

# Function to check if a version string meets a minimum requirement
compare_versions() {
    required_version="$1"
    installed_version="$2"

    if [[ "$(printf '%s\n' "$required_version" "$installed_version" | sort -V | head -n 1)" != "$required_version" ]]; then
        return 1
    fi
}

# Check if Docker is installed
if command -v docker &>/dev/null; then
  echo "Docker is installed on this system."
else
  echo "Error: Docker is not installed on this system."
  exit 1
fi

# Check .NET Core version
dotnet_version=$(dotnet --version 2>&1)
required_dotnet_version="7"

# Check Node.js version
node_version=$(node --version | cut -c 2-)
required_node_version="16"

# Check if .NET Core is installed and meets the version requirement
if ! command -v dotnet &> /dev/null || ! compare_versions "$required_dotnet_version" "$dotnet_version"; then
    echo "Error: .NET version $required_dotnet_version or higher is required or .NET is not installed."
    exit 1
fi

if ! command -v node &> /dev/null || ! compare_versions "$required_node_version" "$node_version"; then
    echo "Error: Node.js version $required_node_version or higher is required or Node.js is not installed."
    exit 1
fi

echo "Environment check passed:"
echo "  .NET version: $dotnet_version"
echo "  Node.js version: $node_version"
