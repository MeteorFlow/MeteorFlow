# Define the root directory
$scriptPath = $MyInvocation.MyCommand.Path
$rootDir = (Get-Item -Path $scriptPath | Resolve-Path).Path | Split-Path -Parent
$parentDir = Split-Path -Parent $rootDir

# Function to clean packages for a .NET project
function Clean-DotNetProject {
    param (
        [string]$projectDir
    )

    # Navigate to the project directory
    Set-Location -Path $projectDir

    # Check if it's a .NET project (contains a .csproj file)
    if (Test-Path -Path "*.csproj") {
        # Run dotnet clean to remove build artifacts
        Write-Host "Cleaning .NET project in $projectDir"
        dotnet clean

        # Remove bin and obj directories
        Remove-Item -Path "bin","obj" -Recurse -Force
    }

    # Navigate back to the src/ directory
    Set-Location -Path $parentDir
}

# Navigate to the src/ directory
Set-Location -Path "$parentDir/src"

# Iterate over each directory in src/
foreach ($projectDir in Get-ChildItem -Directory) {
    if (Test-Path -Path $projectDir.FullName) {
        Clean-DotNetProject $projectDir.FullName
    }
}

# Check if it's a directory
if (Test-Path -Path "$parentDir/src/MeteorFlow.Web" -PathType Container) {
    # Navigate to the MeteorFlow.Web directory
    Set-Location -Path "$parentDir/src/MeteorFlow.Web"

    # Run npm ci to clean npm packages
    Write-Host "Cleaning npm packages in MeteorFlow.Web"
    npm ci
}

# Return to the original directory
Set-Location -Path $parentDir

# Stop and remove Docker containers
Write-Host "Stopping and removing SQL Server Docker containers"
docker-compose down
