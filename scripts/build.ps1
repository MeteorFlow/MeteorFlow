# Define the root directory
$scriptPath = $MyInvocation.MyCommand.Path
$rootDir = (Get-Item -Path $scriptPath | Resolve-Path).Path | Split-Path -Parent
$parentDir = Split-Path -Parent $rootDir

# Navigate to the src/MeteorFlow.Web directory
Set-Location -Path "$parentDir/src/MeteorFlow.Web"

# Build the Vite React-TS project
Write-Host "Building Vite React-TS project..."
npm run build

# Navigate back to the root directory
Set-Location -Path $rootDir

# Build the .NET solutions in the src/ directory
Write-Host "Building .NET solutions..."
dotnet build "D:/bt bk/thesis/MeteorFlow/src/MeteorFlow.sln"