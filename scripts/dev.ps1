# Define the root directory
$scriptPath = $MyInvocation.MyCommand.Path
$rootDir = (Get-Item -Path $scriptPath | Resolve-Path).Path | Split-Path -Parent
$parentDir = Split-Path -Parent $rootDir

Write-Host "Directory: $rootDir"

# Define the path to the web project
$webProjectPath = Join-Path -Path $parentDir -ChildPath "src/MeteorFlow.Web"

# Check if the web project directory exists
if (-not (Test-Path -Path $webProjectPath -PathType Container)) {
    Write-Host "Error: Web project directory not found at $webProjectPath"
    exit 1
}

# Start a new terminal window and run the .NET solution in it
Start-Process -FilePath "powershell" -ArgumentList "-NoProfile -NoExit -Command 'cd $webProjectPath\; dotnet run'" -Wait

# Wait for a moment to allow the .NET application to start (you can adjust the sleep time)
Start-Sleep -Seconds 5

# Navigate to the web project directory
Set-Location -Path $webProjectPath

# Start the Vite React-TS development server
Write-Host "Starting Vite React-TS project..."
npm run dev