param (
	$migrationName,
	[switch]$add = $false,
	[switch]$remove = $false,
	[switch]$update = $false
)

if ($add)
{
	if($migrationName -eq $null)
	{
		Write-Host "missing -migrationName parameter"
		exit
	}
	dotnet ef migrations add $migrationName --project src/Infrastructure -s src/API --context ApplicationDbContext -v
	dotnet ef migrations script --project src/Infrastructure -s src/API --context ApplicationDbContext --output src/Infrastructure/Migrations/MigrationSql/Migration.sql --idempotent
}
if($remove)
{
	dotnet ef migrations remove --project src/Infrastructure -s src/API --context ApplicationDbContext -v
	dotnet ef migrations script --project src/Infrastructure -s src/API --context ApplicationDbContext --output src/Infrastructure/Migrations/MigrationSql/Migration.sql --idempotent
}
if($update)
{
	if ($migrationName -eq $null) {
		dotnet ef database update --project src/Infrastructure -s src/API --context ApplicationDbContext -v	
	} else {
		dotnet ef database update --project src/Infrastructure -s src/API --context ApplicationDbContext $migrationName -v
	}
}