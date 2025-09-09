Write-Host "=== Nettoyage et recompilation OCP Sales Portal ===" -ForegroundColor Green
Write-Host ""

Write-Host "1. Nettoyage des dossiers de build..." -ForegroundColor Yellow
$folders = @(
    "eCommerce.Model\bin",
    "eCommerce.Model\obj",
    "eCommerce.DAL\bin", 
    "eCommerce.DAL\obj",
    "eCommerce.Services\bin",
    "eCommerce.Services\obj",
    "eCommerce.Contracts\bin",
    "eCommerce.Contracts\obj",
    "eCommerce.WebUI\bin",
    "eCommerce.WebUI\obj"
)

foreach ($folder in $folders) {
    if (Test-Path $folder) {
        Remove-Item -Path $folder -Recurse -Force
        Write-Host "✓ Supprimé : $folder" -ForegroundColor Green
    } else {
        Write-Host "✓ Déjà propre : $folder" -ForegroundColor Cyan
    }
}

Write-Host ""
Write-Host "2. Vérification des versions de framework..." -ForegroundColor Yellow

$projects = @(
    @{Name="eCommerce.Model"; File="eCommerce.Model\eCommerce.Model.csproj"},
    @{Name="eCommerce.DAL"; File="eCommerce.DAL\eCommerce.DAL.csproj"},
    @{Name="eCommerce.Services"; File="eCommerce.Services\eCommerce.Services.csproj"},
    @{Name="eCommerce.Contracts"; File="eCommerce.Contracts\eCommerce.Contracts.csproj"},
    @{Name="eCommerce.WebUI"; File="eCommerce.WebUI\eCommerce.WebUI.csproj"}
)

foreach ($project in $projects) {
    if (Test-Path $project.File) {
        $content = Get-Content $project.File -Raw
        if ($content -match 'TargetFrameworkVersion>v4\.8<') {
            Write-Host "✓ $($project.Name) : .NET Framework 4.8" -ForegroundColor Green
        } else {
            Write-Host "⚠ $($project.Name) : Version différente détectée" -ForegroundColor Yellow
        }
    } else {
        Write-Host "✗ $($project.Name) : Fichier projet non trouvé" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "3. Instructions pour Visual Studio..." -ForegroundColor Yellow
Write-Host ""
Write-Host "Maintenant dans Visual Studio :" -ForegroundColor Cyan
Write-Host "1. Ouvrez eCommerce.sln" -ForegroundColor White
Write-Host "2. Clic droit sur la solution → Clean Solution" -ForegroundColor White
Write-Host "3. Clic droit sur la solution → Restore NuGet Packages" -ForegroundColor White
Write-Host "4. Build → Build Solution (Ctrl+Shift+B)" -ForegroundColor White
Write-Host "5. Debug → Start Debugging (F5)" -ForegroundColor White
Write-Host ""

Write-Host "✅ Nettoyage terminé ! Le projet devrait maintenant compiler sans erreur." -ForegroundColor Green 