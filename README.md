# OCP Sales Portal - eCommerce Platform

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/download/dotnet-framework)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.1.3-green.svg)](https://docs.microsoft.com/en-us/ef/)
[![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5.2.3-red.svg)](https://docs.microsoft.com/en-us/aspnet/mvc/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Description

**OCP Sales Portal** est une plateforme eCommerce interne développée pour le Groupe OCP (Office Chérifien des Phosphates). Cette application permet aux employés d'OCP de commander des produits industriels, des équipements, des pièces détachées et des services techniques directement via un portail web sécurisé.

## Fonctionnalités Principales

### **Catalogue de Produits**
- Navigation par catégories (Engrais, Équipements Industriels, Pièces Détachées, etc.)
- Recherche avancée avec filtres
- Pagination pour optimiser les performances
- Affichage des spécifications techniques détaillées
- Gestion des stocks en temps réel

### **Gestion du Panier**
- Ajout/suppression de produits
- Modification des quantités
- Calcul automatique des totaux
- Persistance de session

### **Système de Commandes**
- Processus de checkout simplifié
- Informations client et département
- Génération de commandes avec numérotation
- Confirmation de commande

### **Interface d'Administration**
- Gestion des produits (CRUD complet)
- Gestion des catégories
- Interface sécurisée pour les administrateurs

## Architecture Technique

### **Pattern Architectural**
- **Architecture N-Tier** avec séparation claire des responsabilités
- **Pattern Repository** pour l'accès aux données
- **Dependency Injection** avec Unity Container
- **Code First** avec Entity Framework

### **Couches de l'Application**
```
📁 eCommerce.Contracts    # Interfaces et contrats
📁 eCommerce.Model        # Entités métier
📁 eCommerce.DAL          # Accès aux données (Data Access Layer)
📁 eCommerce.Services     # Logique métier
📁 eCommerce.WebUI        # Interface utilisateur (MVC)
```

## 🛠️ Technologies Utilisées

| Technologie | Version | Description |
|-------------|---------|-------------|
| **.NET Framework** | 4.8 | Plateforme de développement |
| **ASP.NET MVC** | 5.2.3 | Framework web |
| **Entity Framework** | 6.1.3 | ORM pour la base de données |
| **SQL Server** | LocalDB | Base de données |
| **Bootstrap** | 3.3.7 | Framework CSS |
| **jQuery** | 3.1.1 | Bibliothèque JavaScript |
| **Unity Container** | 5.11.1 | Injection de dépendances |

## Installation et Configuration

### **Prérequis**
- Visual Studio 2017 ou supérieur
- .NET Framework 4.8
- SQL Server LocalDB
- Git

### **Étapes d'Installation**

1. **Cloner le repository**
   ```bash
   git clone https://github.com/votre-username/ocp-sales-portal.git
   cd ocp-sales-portal
   ```

2. **Restaurer les packages NuGet**
   ```bash
   # Dans Visual Studio : Tools > NuGet Package Manager > Package Manager Console
   Update-Package -reinstall
   ```

3. **Configurer la base de données**
   - Ouvrir le projet dans Visual Studio
   - Exécuter les migrations Entity Framework
   - La base de données sera créée automatiquement avec des données de test

4. **Lancer l'application**
   - Appuyer sur F5 ou Ctrl+F5
   - L'application s'ouvrira dans votre navigateur

## Modèle de Données

### **Entités Principales**
- **Product** : Produits avec spécifications techniques
- **Category** : Catégories de produits
- **Order** : Commandes clients
- **OrderItem** : Articles de commande
- **Customer** : Informations clients
- **Basket** : Panier de session
- **BasketItem** : Articles du panier

### **Relations**
- Category → Products (One-to-Many)
- Order → OrderItems (One-to-Many)
- Product → OrderItems (One-to-Many)
- Basket → BasketItems (One-to-Many)

## Interface Utilisateur

### **Design System**
- **Couleurs OCP** : Vert corporatif (#2E7D32), Bleu (#1976D2)
- **Responsive Design** : Adaptatif mobile et desktop
- **Bootstrap 3** : Framework CSS moderne
- **UX Optimisée** : Navigation intuitive et feedback utilisateur

### **Pages Principales**
- **Accueil** : Vue d'ensemble du catalogue
- **Catalogue** : Liste des produits avec filtres
- **Détails Produit** : Spécifications complètes
- **Panier** : Gestion des articles sélectionnés
- **Checkout** : Processus de commande
- **Administration** : Interface de gestion

## Configuration

### **Chaîne de Connexion**
```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=OCPSalesPortal;Integrated Security=True;MultipleActiveResultSets=True" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### **Paramètres d'Application**
```xml
<appSettings>
  <add key="ApplicationName" value="OCP Sales Portal"/>
  <add key="CompanyName" value="OCP Groupe"/>
</appSettings>
```

## Données de Test

L'application inclut un initialiseur de données avec :
- **6 catégories** : Engrais, Équipements Industriels, Pièces Détachées, Services Techniques, Outillage, Sécurité
- **12 produits** : Exemples réalistes d'équipements OCP
- **Spécifications techniques** : Données détaillées pour chaque produit

## Développement

### **Structure du Projet**
```
eCommerce-master/
├── eCommerce.Contracts/          # Interfaces
│   └── Repositories/
├── eCommerce.Model/              # Entités
├── eCommerce.DAL/                # Accès données
│   ├── Data/
│   ├── Migrations/
│   └── Repositories/
├── eCommerce.Services/           # Logique métier
├── eCommerce.WebUI/              # Interface web
│   ├── Controllers/
│   ├── Views/
│   ├── Models/
│   └── Content/
└── Scripts/                      # Scripts PowerShell
```

### **Scripts PowerShell**
- `CleanAndBuild.ps1` : Nettoyage et compilation
- `CompileServices.ps1` : Compilation des services
- `TestOCPSalesPortal.ps1` : Tests de l'application
- `UpdatePackages.ps1` : Mise à jour des packages

## Sécurité

### **Mesures Implémentées**
- Validation des entrées utilisateur
- Tokens anti-forgery sur les formulaires
- Autorisation par rôles
- Protection contre l'injection SQL (Entity Framework)

### **Recommandations**
- Implémenter l'authentification complète
- Ajouter des logs de sécurité
- Chiffrer les données sensibles
- Mettre en place HTTPS

## 🚀 Déploiement

### **Environnement de Production**
1. Configurer la chaîne de connexion de production
2. Activer l'authentification
3. Configurer HTTPS
4. Optimiser les performances (cache, compression)
5. Mettre en place la surveillance

## Changelog

### **Version 1.0.0** (2024)
- ✅ Architecture N-Tier implémentée
- ✅ Catalogue de produits fonctionnel
- ✅ Système de panier et commandes
- ✅ Interface d'administration
- ✅ Design responsive OCP
- ✅ Données de test complètes

## Contribution

### **Comment Contribuer**
1. Fork le projet
2. Créer une branche feature (`git checkout -b feature/AmazingFeature`)
3. Commit vos changements (`git commit -m 'Add some AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

### **Standards de Code**
- Suivre les conventions C# Microsoft
- Commenter le code complexe
- Ajouter des tests unitaires
- Documenter les nouvelles fonctionnalités

## Licence

Ce projet est sous licence MIT.

## Équipe

- **Développeur Principal** : Aymane BAKACHE 
- **Stage** : OCP Groupe
- **Période** : 01-08/2025 ---> 31/08/2025

## Contact

- **Email** : aymanbakach7@gmail.com
- **LinkedIn** : (https://www.linkedin.com/in/aymane-bakache)
- **GitHub** : @aymanebakache

## Remerciements

- OCP Groupe pour l'opportunité de stage
- Équipe de développement pour le support Rachid Nmissi
- Communauté .NET pour les ressources

---

<div align="center">
  <strong>Développé avec ❤️ pour OCP Groupe</strong>
</div>
