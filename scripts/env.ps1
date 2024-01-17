# Function to check if a version string meets a minimum requirement
function Compare-Version($versionString, $requiredVersion) {
    [version]$version = $versionString -replace "^v", ""  # Remove 'v' character
    [version]$required = $requiredVersion
    return $version -ge $required
}

# Check if Docker is installed
if (Test-Path -Path "C:\Program Files\Docker\Docker\docker.exe") {
    Write-Host "Docker is installed on this system."
} elseif (Get-Command docker -ErrorAction SilentlyContinue) {
    Write-Host "Docker is installed on this system."
} else {
    Write-Host "Error: Docker is not installed on this system."
    exit 1
}

# Check if .NET Core is installed and get its version
$dotnet_version = & dotnet --version 2>&1
$required_dotnet_version = [version]"8.0"

# Check if Node.js is installed and get its version
$node_version = & node --version 2>&1
$required_node_version = [version]"16.0"

# Check if .NET Core is installed and meets the version requirement
if ($LASTEXITCODE -ne 0 -or -not (Compare-Version $dotnet_version $required_dotnet_version)) {
    Write-Host "Error: .NET version $required_dotnet_version or higher is required or .NET is not installed."
    exit 1
}

# Check if Node.js is installed and meets the version requirement
if ($LASTEXITCODE -ne 0 -or -not (Compare-Version $node_version $required_node_version)) {
    Write-Host "Error: Node.js version $required_node_version or higher is required or Node.js is not installed."
    exit 1
}


Write-Host "Environment check passed:"
Write-Host "  .NET version: $dotnet_version"
Write-Host "  Node.js version: $node_version"
