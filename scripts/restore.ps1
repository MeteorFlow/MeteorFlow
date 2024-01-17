# Define the root directory
$scriptPath = $MyInvocation.MyCommand.Path
$rootDir = (Get-Item -Path $scriptPath | Resolve-Path).Path | Split-Path -Parent
$parentDir = Split-Path -Parent $rootDir

# Navigate to the src/ directory
Set-Location -Path "$parentDir/src"

# Iterate over each directory in src/
foreach ($projectDir in Get-ChildItem -Directory) {
    if (Test-Path -Path $projectDir.FullName) {
        # Check if it's a .NET project (contains a .csproj file)
        if (Test-Path -Path "$projectDir\*.csproj") {
            # Run dotnet restore
            Write-Host "Restoring .NET project in $($projectDir.FullName)"
            dotnet restore
        }
    }
}

# Check if it's a directory
if (Test-Path -Path "$parentDir/src/MeteorFlow.Web" -PathType Container) {
    # Navigate to the MeteorFlow.Web directory
    Set-Location -Path "$parentDir/src/MeteorFlow.Web"
    # Run npm ci
    Write-Host "Running 'npm ci' in MeteorFlow.Web"
    npm ci
}

# Return to the original directory
Set-Location -Path $parentDir

# Start Docker containers
Write-Host "Retrieving SQL Server Docker Image"
docker-compose up -d
