# set output encoding
$OutputEncoding = [Text.UTF8Encoding]::UTF8

# company name placeholder 
$oldCompanyName="CName"
# your company name
$newCompanyName="YCompany"

# project name placeholder
$oldProjectName="PName"
# your project name
$newProjectName="YProject"

$oldServiceName="SName"
$newServiceName="YService"

if ($args.Length -gt 0) {
    $newCompanyName = $args[0]
}

if ($args.Length -gt 1) {
    $newProjectName = $args[1]
}

if ($args.Length -gt 2) {
    $newServiceName = $args[2]
}

# file type
$fileType="FileInfo"

# directory type
$dirType="DirectoryInfo"

$baseFolder="aspnet-core"

# copy 
Write-Host 'Start copy folders...'
$newRoot=$newCompanyName+"."+$newProjectName+"."+$newServiceName
mkdir $newRoot
Copy-Item -Recurse .\$baseFolder\ .\$newRoot\
Copy-Item .gitignore .\$newRoot\
Copy-Item LICENSE .\$newRoot\
Copy-Item README.md .\$newRoot\

# folders to deal with
$slnFolder = (Get-Item -Path "./$newRoot/$baseFolder/" -Verbose).FullName

function Rename {
	param (
		$TargetFolder,
		$PlaceHolderCompanyName,
		$PlaceHolderProjectName,
		$PlaceHolderServiceName,
		$NewCompanyName,
		$NewProjectName,
		$NewServiceName
	)
	# file extensions to deal with
	$include=@("*.cs","*.cshtml","*.asax","*.ps1","*.ts","*.csproj","*.sln","*.xaml","*.json","*.js","*.xml","*.config","Dockerfile","*.DotSettings")

	$elapsed = [System.Diagnostics.Stopwatch]::StartNew()

	Write-Host "[$TargetFolder]Start rename folder..."
	# rename folder
	Ls $TargetFolder -Recurse | Where { $_.GetType().Name -eq $dirType -and ($_.Name.Contains($PlaceHolderCompanyName) -or $_.Name.Contains($PlaceHolderProjectName) -or $_.Name.Contains($PlaceHolderServiceName)) } | ForEach-Object{
		Write-Host 'directory ' $_.FullName
		$newDirectoryName=$_.Name.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName).Replace($PlaceHolderServiceName,$NewServiceName)
		Rename-Item $_.FullName $newDirectoryName
	}
	Write-Host "[$TargetFolder]End rename folder."
	Write-Host '-------------------------------------------------------------'

	# replace file content and rename file name
	Write-Host "[$TargetFolder]Start replace file content and rename file name..."
	Ls $TargetFolder -Include $include -Recurse | Where { $_.GetType().Name -eq $fileType} | ForEach-Object{
		$fileText = Get-Content $_ -Raw -Encoding UTF8
		if($fileText.Length -gt 0 -and ($fileText.contains($PlaceHolderCompanyName) -or $fileText.contains($PlaceHolderProjectName) -or $fileText.Contains($PlaceHolderServiceName))){
			$fileText.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName).Replace($PlaceHolderServiceName,$NewServiceName) | Set-Content $_ -Encoding UTF8
			Write-Host 'file(change text) ' $_.FullName
		}
		If($_.Name.contains($PlaceHolderCompanyName) -or $_.Name.contains($PlaceHolderProjectName) -or $_.Name.Contains($PlaceHolderServiceName)){
			$newFileName=$_.Name.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName).Replace($PlaceHolderServiceName,$NewServiceName)
			Rename-Item $_.FullName $newFileName
			Write-Host 'file(change name) ' $_.FullName
		}
	}
	Write-Host "[$TargetFolder]End replace file content and rename file name."
	Write-Host '-------------------------------------------------------------'

	$elapsed.stop()
	write-host "[$TargetFolder]Total Time Cost: $($elapsed.Elapsed.ToString())"
}

Rename -TargetFolder $slnFolder -PlaceHolderCompanyName $oldCompanyName -PlaceHolderProjectName $oldProjectName -PlaceHolderServiceName $oldServiceName -NewCompanyName $newCompanyName -NewProjectName $newProjectName -NewServiceName $newServiceName

dotnet restore "$slnFolder$newRoot.sln"