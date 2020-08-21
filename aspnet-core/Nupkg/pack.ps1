# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

Set-Location $rootFolder
& dotnet restore

$projects=(
"src/CName.PName.SName.HttpApi.Client",
"src/CName.PName.SName.Application.Contracts",
"src/CName.PName.SName.Domain.Shared"
)

foreach ($project in $projects) {
    $projectFolder= Join-Path $rootFolder $project

    Set-Location $projectFolder
    
    & dotnet msbuild /t:pack /p:Configuration=Release /p:SourceLinkCreate=false

    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $projectFolder)
        exit $LASTEXITCODE
    }
    
    # Copy nuget package
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $projectName + ".*.nupkg")
    Move-Item $projectPackPath $packFolder
}

Set-Location $packFolder