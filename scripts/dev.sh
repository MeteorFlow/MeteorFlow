#!/bin/bash

# Define the root directory
root_dir="$(dirname "$(dirname "$(readlink -f "$0")")")"

echo "Directory: $root_dir"

# Define the path to the web project
web_project_path="$root_dir/src/MeteorFlow.Web"

# Check if the web project directory exists
if [ ! -d "$web_project_path" ]; then
  echo "Error: Web project directory not found at $web_project_path"
  exit 1
fi

# Function to open a new terminal window and run a command (macOS)
open_terminal_macos() {
    local command_to_run="$1"
    if [ -z "$command_to_run" ]; then
        echo "Usage: open_terminal_macos <command>"
        return 1
    fi
    
    echo $command_to_run

    if [ "$(uname)" == "Darwin" ]; then
        osascript -e 'tell application "Terminal" to do script "'"${command_to_run}"'"'
    else
        echo "Unsupported operating system."
    fi
}

# Function to open a new terminal window and run a command (Linux)
open_terminal_linux() {
    local command_to_run="$1"
    if [ -z "$command_to_run" ]; then
        echo "Usage: open_terminal_linux <command>"
        return 1
    fi
    
    echo $command_to_run

    if [ "$(expr substr "$(uname -s)" 1 5)" == "Linux" ]; then
        gnome-terminal -- bash -c "$command_to_run; exec bash"
    else
        echo "Unsupported operating system."
    fi
}

# Run the .NET solution in the background (if needed)
if [ "$(uname)" == "Darwin" ]; then
    open_terminal_macos "cd $web_project_path && dotnet run"
else
    open_terminal_linux "cd $web_project_path && dotnet run"
fi

# Wait for a moment to allow the .NET application to start
sleep 5

# Navigate to the web project directory
cd "$web_project_path" || exit

# Start the Vite React-TS development server
echo "Starting Vite React-TS project..."
npm run dev