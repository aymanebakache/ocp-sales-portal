Write-Host "=== Diagnostic et correction du projet Services ===" -ForegroundColor Green
Write-Host ""

Write-Host "1. Vérification du fichier projet Services..." -ForegroundColor Yellow

$projectFile = "eCommerce.Services\eCommerce.Services.csproj"

if (Test-Path $projectFile) {
    Write-Host "✓ Fichier projet trouvé : $projectFile" -ForegroundColor Green
    
    # Lire le contenu du fichier projet
    $content = Get-Content $projectFile -Raw
    
    # Vérifier la version du framework
    if ($content -match 'TargetFrameworkVersion>v4\.8<') {
        Write-Host "✓ Version du framework : .NET Framework 4.8" -ForegroundColor Green
    } else {
        Write-Host "⚠ Problème de version du framework détecté" -ForegroundColor Yellow
    }
    
    # Vérifier les références de projet
    if ($content -match 'eCommerce.Model') {
        Write-Host "✓ Référence vers eCommerce.Model trouvée" -ForegroundColor Green
    } else {
        Write-Host "✗ Référence vers eCommerce.Model manquante" -ForegroundColor Red
    }
    
    if ($content -match 'eCommerce.DAL') {
        Write-Host "✓ Référence vers eCommerce.DAL trouvée" -ForegroundColor Green
    } else {
        Write-Host "✗ Référence vers eCommerce.DAL manquante" -ForegroundColor Red
    }
    
    if ($content -match 'eCommerce.Contracts') {
        Write-Host "✓ Référence vers eCommerce.Contracts trouvée" -ForegroundColor Green
    } else {
        Write-Host "✗ Référence vers eCommerce.Contracts manquante" -ForegroundColor Red
    }
    
} else {
    Write-Host "✗ Fichier projet non trouvé : $projectFile" -ForegroundColor Red
}

Write-Host ""
Write-Host "2. Vérification des fichiers sources..." -ForegroundColor Yellow

$sourceFiles = @(
    "eCommerce.Services\BasketService.cs",
    "eCommerce.Services\Properties\AssemblyInfo.cs"
)

foreach ($file in $sourceFiles) {
    if (Test-Path $file) {
        Write-Host "✓ $file" -ForegroundColor Green
    } else {
        Write-Host "✗ $file - MANQUANT" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "3. Instructions pour corriger dans Visual Studio..." -ForegroundColor Yellow
Write-Host ""
Write-Host "Dans Visual Studio :" -ForegroundColor Cyan
Write-Host "1. Clic droit sur 'eCommerce.Services (unloaded)'" -ForegroundColor White
Write-Host "2. Sélectionnez 'Reload Project'" -ForegroundColor White
Write-Host ""
Write-Host "Si cela ne fonctionne pas :" -ForegroundColor Cyan
Write-Host "1. Clic droit sur 'eCommerce.Services (unloaded)'" -ForegroundColor White
Write-Host "2. Sélectionnez 'Unload Project'" -ForegroundColor White
Write-Host "3. Clic droit à nouveau" -ForegroundColor White
Write-Host "4. Sélectionnez 'Reload Project'" -ForegroundColor White
Write-Host ""
Write-Host "Si le problème persiste :" -ForegroundColor Cyan
Write-Host "1. Fermez Visual Studio" -ForegroundColor White
Write-Host "2. Supprimez le dossier eCommerce.Services\obj" -ForegroundColor White
Write-Host "3. Rouvrez Visual Studio" -ForegroundColor White
Write-Host "4. Rechargez le projet" -ForegroundColor White
Write-Host ""

Write-Host "✅ Diagnostic terminé. Suivez les instructions ci-dessus." -ForegroundColor Green 