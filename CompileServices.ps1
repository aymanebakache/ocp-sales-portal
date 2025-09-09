Write-Host "=== Compilation du projet Services ===" -ForegroundColor Green
Write-Host ""

Write-Host "1. Vérification des dépendances..." -ForegroundColor Yellow

# Vérifier que les projets de dépendance existent
$dependencies = @(
    "eCommerce.Model\bin\Debug\eCommerce.Model.dll",
    "eCommerce.DAL\bin\Debug\eCommerce.DAL.dll",
    "eCommerce.Contracts\bin\Debug\eCommerce.Contracts.dll"
)

foreach ($dep in $dependencies) {
    if (Test-Path $dep) {
        Write-Host "✓ $dep" -ForegroundColor Green
    } else {
        Write-Host "✗ $dep - MANQUANT" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "2. Nettoyage du projet Services..." -ForegroundColor Yellow

# Nettoyer le projet Services
$serviceFolders = @(
    "eCommerce.Services\bin",
    "eCommerce.Services\obj"
)

foreach ($folder in $serviceFolders) {
    if (Test-Path $folder) {
        Remove-Item -Path $folder -Recurse -Force
        Write-Host "✓ Nettoyé : $folder" -ForegroundColor Green
    }
}

Write-Host ""
Write-Host "3. Instructions pour Visual Studio..." -ForegroundColor Yellow
Write-Host ""
Write-Host "Dans Visual Studio, compilez dans cet ordre :" -ForegroundColor Cyan
Write-Host "1. Clic droit sur eCommerce.Model → Build" -ForegroundColor White
Write-Host "2. Clic droit sur eCommerce.Contracts → Build" -ForegroundColor White
Write-Host "3. Clic droit sur eCommerce.DAL → Build" -ForegroundColor White
Write-Host "4. Clic droit sur eCommerce.Services → Build" -ForegroundColor White
Write-Host "5. Clic droit sur eCommerce.WebUI → Build" -ForegroundColor White
Write-Host ""
Write-Host "Ou utilisez : Build → Build Solution (Ctrl+Shift+B)" -ForegroundColor Cyan
Write-Host ""

Write-Host "✅ Instructions données. Le projet Services devrait maintenant compiler." -ForegroundColor Green 