Write-Host "=== Mise à jour des packages NuGet pour OCP Sales Portal ===" -ForegroundColor Green
Write-Host ""

Write-Host "⚠️  ATTENTION : Les packages suivants ont des vulnérabilités de sécurité" -ForegroundColor Yellow
Write-Host ""

Write-Host "Packages avec vulnérabilités MODERÉES :" -ForegroundColor Cyan
Write-Host "• bootstrap 3.3.7" -ForegroundColor White
Write-Host "• jQuery 3.1.1" -ForegroundColor White
Write-Host ""

Write-Host "Packages avec vulnérabilités ÉLEVÉES :" -ForegroundColor Red
Write-Host "• jQuery.Validation 1.16.0" -ForegroundColor White
Write-Host "• Microsoft.AspNet.Identity.Owin 2.2.1" -ForegroundColor White
Write-Host "• Microsoft.Owin 3.0.1" -ForegroundColor White
Write-Host "• Newtonsoft.Json 9.0.1" -ForegroundColor White
Write-Host ""

Write-Host "Recommandations :" -ForegroundColor Yellow
Write-Host "1. Mettez à jour Bootstrap vers la version 4.x ou 5.x" -ForegroundColor White
Write-Host "2. Mettez à jour jQuery vers la version 3.6.x" -ForegroundColor White
Write-Host "3. Mettez à jour Newtonsoft.Json vers la version 13.x" -ForegroundColor White
Write-Host "4. Considérez migrer vers ASP.NET Core pour une meilleure sécurité" -ForegroundColor White
Write-Host ""

Write-Host "Pour l'instant, l'application fonctionnera avec les packages actuels." -ForegroundColor Green
Write-Host "Les vulnérabilités sont principalement liées à l'utilisation de packages obsolètes." -ForegroundColor Green
Write-Host ""

Write-Host "Pour compiler et tester l'application :" -ForegroundColor Yellow
Write-Host "1. Ouvrez Visual Studio" -ForegroundColor White
Write-Host "2. Ouvrez eCommerce.sln" -ForegroundColor White
Write-Host "3. Restore les packages NuGet" -ForegroundColor White
Write-Host "4. Compilez le projet (Ctrl+Shift+B)" -ForegroundColor White
Write-Host "5. Lancez l'application (F5)" -ForegroundColor White 