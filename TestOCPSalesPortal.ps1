# Script de test et configuration pour OCP Sales Portal
Write-Host "=== Test et Configuration OCP Sales Portal ===" -ForegroundColor Green
Write-Host ""

# 1. Vérifier la structure du projet
Write-Host "1. Vérification de la structure du projet..." -ForegroundColor Yellow
$requiredFiles = @(
    "eCommerce.Model\Category.cs",
    "eCommerce.Model\Product.cs", 
    "eCommerce.DAL\Data\DataContext.cs",
    "eCommerce.WebUI\Controllers\ProductsController.cs",
    "eCommerce.WebUI\Controllers\BasketController.cs",
    "eCommerce.WebUI\Views\Products\Index.cshtml",
    "eCommerce.WebUI\Views\Basket\Index.cshtml"
)

$missingFiles = @()
foreach ($file in $requiredFiles) {
    if (Test-Path $file) {
        Write-Host "✓ $file" -ForegroundColor Green
    } else {
        Write-Host "✗ $file - MANQUANT" -ForegroundColor Red
        $missingFiles += $file
    }
}

if ($missingFiles.Count -gt 0) {
    Write-Host ""
    Write-Host "ERREUR : Fichiers manquants détectés!" -ForegroundColor Red
    foreach ($file in $missingFiles) {
        Write-Host "  - $file" -ForegroundColor Red
    }
    exit 1
}

Write-Host ""
Write-Host "✓ Tous les fichiers requis sont présents" -ForegroundColor Green

# 2. Vérifier la configuration Web.config
Write-Host ""
Write-Host "2. Vérification de la configuration..." -ForegroundColor Yellow
$webConfig = "eCommerce.WebUI\Web.config"
if (Test-Path $webConfig) {
    Write-Host "✓ Web.config trouvé" -ForegroundColor Green
    Write-Host "  Base de données : OCPSalesPortal" -ForegroundColor Cyan
} else {
    Write-Host "✗ Web.config non trouvé" -ForegroundColor Red
}

# 3. Créer un dossier d'images pour les produits
Write-Host ""
Write-Host "3. Configuration des ressources..." -ForegroundColor Yellow
$imagesFolder = "eCommerce.WebUI\Images"
if (!(Test-Path $imagesFolder)) {
    New-Item -ItemType Directory -Path $imagesFolder -Force
    Write-Host "✓ Dossier Images créé" -ForegroundColor Green
} else {
    Write-Host "✓ Dossier Images existe déjà" -ForegroundColor Green
}

# 4. Créer un fichier README avec les instructions
Write-Host ""
Write-Host "4. Création du fichier README..." -ForegroundColor Yellow
$readmeContent = @"
# OCP Sales Portal - Guide d'installation

## Prérequis
- Visual Studio 2019 ou plus récent
- SQL Server LocalDB
- .NET Framework 4.8

## Installation

1. Ouvrez le projet dans Visual Studio
2. Restore les packages NuGet
3. Compilez le projet (Ctrl+Shift+B)
4. Lancez l'application (F5)

## Fonctionnalités disponibles

### Front-office
- Page d'accueil avec présentation OCP
- Catalogue de produits avec filtres par catégorie
- Recherche de produits
- Panier d'achat avec gestion des quantités
- Formulaire de commande avec département/service
- Confirmation de commande professionnelle

### Catégories OCP
- Engrais
- Équipements Industriels
- Pièces Détachées
- Services Techniques
- Outillage
- Sécurité

### URL de test
- Accueil : http://localhost:port/
- Catalogue : http://localhost:port/Products
- Panier : http://localhost:port/Basket

## Configuration de la base de données

L'application utilise Entity Framework avec SQL Server LocalDB.
La base de données sera créée automatiquement au premier lancement.

## Personnalisation

Pour ajouter des images de produits :
1. Placez les images dans le dossier eCommerce.WebUI\Images
2. Mettez à jour le champ ImageUrl des produits

Pour modifier les catégories :
1. Éditez le fichier eCommerce.DAL\Migrations\OCPDataInitializer.cs
2. Relancez l'application

## Support

Pour toute question ou problème, contactez l'équipe de développement.
"@

$readmeContent | Out-File -FilePath "README_OCP.md" -Encoding UTF8
Write-Host "✓ Fichier README créé : README_OCP.md" -ForegroundColor Green

# 5. Instructions pour l'utilisateur
Write-Host ""
Write-Host "=== Instructions pour finaliser l'installation ===" -ForegroundColor Green
Write-Host ""
Write-Host "1. Ouvrez Visual Studio et compilez le projet" -ForegroundColor Cyan
Write-Host "2. Assurez-vous que SQL Server LocalDB est installé" -ForegroundColor Cyan
Write-Host "3. Lancez l'application depuis Visual Studio (F5)" -ForegroundColor Cyan
Write-Host ""
Write-Host "=== Fonctionnalités disponibles ===" -ForegroundColor Green
Write-Host "• Page d'accueil avec présentation OCP" -ForegroundColor White
Write-Host "• Catalogue de produits avec filtres" -ForegroundColor White
Write-Host "• Panier d'achat avec gestion des quantités" -ForegroundColor White
Write-Host "• Formulaire de commande avec département/service" -ForegroundColor White
Write-Host "• Confirmation de commande professionnelle" -ForegroundColor White
Write-Host ""
Write-Host "=== URL de test ===" -ForegroundColor Green
Write-Host "• Accueil : http://localhost:port/" -ForegroundColor White
Write-Host "• Catalogue : http://localhost:port/Products" -ForegroundColor White
Write-Host "• Panier : http://localhost:port/Basket" -ForegroundColor White
Write-Host ""

Write-Host "Configuration terminée avec succès!" -ForegroundColor Green 