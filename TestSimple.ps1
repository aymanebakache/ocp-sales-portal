Write-Host "=== Test OCP Sales Portal ===" -ForegroundColor Green

# Vérifier les fichiers principaux
$files = @(
    "eCommerce.Model\Category.cs",
    "eCommerce.Model\Product.cs",
    "eCommerce.DAL\Data\DataContext.cs",
    "eCommerce.WebUI\Controllers\ProductsController.cs",
    "eCommerce.WebUI\Controllers\BasketController.cs",
    "eCommerce.WebUI\Views\Products\Index.cshtml",
    "eCommerce.WebUI\Views\Basket\Index.cshtml",
    "eCommerce.WebUI\Web.config"
)

$allGood = $true
foreach ($file in $files) {
    if (Test-Path $file) {
        Write-Host "✓ $file" -ForegroundColor Green
    } else {
        Write-Host "✗ $file" -ForegroundColor Red
        $allGood = $false
    }
}

if ($allGood) {
    Write-Host ""
    Write-Host "✓ Tous les fichiers sont présents!" -ForegroundColor Green
    Write-Host ""
    Write-Host "Prochaines étapes:" -ForegroundColor Yellow
    Write-Host "1. Ouvrez Visual Studio" -ForegroundColor White
    Write-Host "2. Ouvrez eCommerce.sln" -ForegroundColor White
    Write-Host "3. Compilez le projet (Ctrl+Shift+B)" -ForegroundColor White
    Write-Host "4. Lancez l'application (F5)" -ForegroundColor White
} else {
    Write-Host ""
    Write-Host "✗ Certains fichiers sont manquants!" -ForegroundColor Red
} 