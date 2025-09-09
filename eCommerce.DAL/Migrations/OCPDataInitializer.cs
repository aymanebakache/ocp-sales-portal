using eCommerce.DAL.Data;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eCommerce.DAL.Migrations
{
    public class OCPDataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Initialiser les catégories OCP
            var categories = new List<Category>
            {
                new Category { Name = "Engrais", Description = "Gamme complète d'engrais et fertilisants", DisplayOrder = 1, IsActive = true },
                new Category { Name = "Équipements Industriels", Description = "Équipements et machines pour l'industrie", DisplayOrder = 2, IsActive = true },
                new Category { Name = "Pièces Détachées", Description = "Pièces de rechange et composants", DisplayOrder = 3, IsActive = true },
                new Category { Name = "Services Techniques", Description = "Services de maintenance et support", DisplayOrder = 4, IsActive = true },
                new Category { Name = "Outillage", Description = "Outils et équipements de travail", DisplayOrder = 5, IsActive = true },
                new Category { Name = "Sécurité", Description = "Équipements de sécurité et protection", DisplayOrder = 6, IsActive = true }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Initialiser les produits OCP
            var products = new List<Product>
            {
                // Engrais
                new Product {
                    Description = "Engrais NPK 15-15-15",
                    Price = 2500.00m,
                    CostPrice = 2000.00m,
                    CategoryId = categories[0].CategoryId,
                    StockQuantity = 100,
                    UnitOfMeasure = "tonnes",
                    TechnicalSpecs = "Composition : N 15%, P2O5 15%, K2O 15%\nGranulométrie : 2-4mm\nSolubilité : Excellente\nEmballage : Big bags 1 tonne",
                    IsActive = true
                },
                new Product {
                    Description = "Engrais phosphaté TSP",
                    Price = 3200.00m,
                    CostPrice = 2600.00m,
                    CategoryId = categories[0].CategoryId,
                    StockQuantity = 75,
                    UnitOfMeasure = "tonnes",
                    TechnicalSpecs = "Composition : P2O5 46%\nGranulométrie : 1-3mm\nSolubilité : Très bonne\nEmballage : Big bags 1 tonne",
                    IsActive = true
                },
                
                // Équipements Industriels
                new Product {
                    Description = "Pompe centrifuge industrielle",
                    Price = 45000.00m,
                    CostPrice = 38000.00m,
                    CategoryId = categories[1].CategoryId,
                    StockQuantity = 5,
                    UnitOfMeasure = "unités",
                    TechnicalSpecs = "Débit : 100-500 m³/h\nPression : 2-8 bar\nPuissance : 15-75 kW\nMatériau : Fonte, acier inoxydable",
                    IsActive = true
                },
                new Product {
                    Description = "Convoyeur à bande 500mm",
                    Price = 15000.00m,
                    CostPrice = 12000.00m,
                    CategoryId = categories[1].CategoryId,
                    StockQuantity = 8,
                    UnitOfMeasure = "mètres",
                    TechnicalSpecs = "Largeur : 500mm\nVitesse : 0.5-2 m/s\nCharge : 500 kg/m\nMoteur : 2.2 kW",
                    IsActive = true
                },
                
                // Pièces Détachées
                new Product {
                    Description = "Roulements SKF 6205",
                    Price = 150.00m,
                    CostPrice = 120.00m,
                    CategoryId = categories[2].CategoryId,
                    StockQuantity = 200,
                    UnitOfMeasure = "pièces",
                    TechnicalSpecs = "Diamètre intérieur : 25mm\nDiamètre extérieur : 52mm\nLargeur : 15mm\nCharge dynamique : 14.0 kN",
                    IsActive = true
                },
                new Product {
                    Description = "Joint d'étanchéité 50mm",
                    Price = 25.00m,
                    CostPrice = 18.00m,
                    CategoryId = categories[2].CategoryId,
                    StockQuantity = 500,
                    UnitOfMeasure = "pièces",
                    TechnicalSpecs = "Diamètre : 50mm\nMatériau : Nitrile\nTempérature : -40°C à +120°C\nPression : 10 bar",
                    IsActive = true
                },
                
                // Services Techniques
                new Product {
                    Description = "Maintenance préventive",
                    Price = 5000.00m,
                    CostPrice = 3500.00m,
                    CategoryId = categories[3].CategoryId,
                    StockQuantity = 999,
                    UnitOfMeasure = "intervention",
                    TechnicalSpecs = "Durée : 1-2 jours\nÉquipe : 2 techniciens\nInclut : Diagnostic, nettoyage, graissage, remplacement pièces d'usure",
                    IsActive = true
                },
                new Product {
                    Description = "Formation technique équipements",
                    Price = 8000.00m,
                    CostPrice = 6000.00m,
                    CategoryId = categories[3].CategoryId,
                    StockQuantity = 999,
                    UnitOfMeasure = "session",
                    TechnicalSpecs = "Durée : 3-5 jours\nParticipants : 5-10 personnes\nInclut : Théorie, pratique, documentation, certificat",
                    IsActive = true
                },
                
                // Outillage
                new Product {
                    Description = "Clé à molette 24\"",
                    Price = 450.00m,
                    CostPrice = 350.00m,
                    CategoryId = categories[4].CategoryId,
                    StockQuantity = 50,
                    UnitOfMeasure = "pièces",
                    TechnicalSpecs = "Ouverture : 0-60mm\nLongueur : 600mm\nMatériau : Acier chromé\nNorme : DIN 3113",
                    IsActive = true
                },
                new Product {
                    Description = "Perceuse à percussion 26mm",
                    Price = 1200.00m,
                    CostPrice = 950.00m,
                    CategoryId = categories[4].CategoryId,
                    StockQuantity = 25,
                    UnitOfMeasure = "pièces",
                    TechnicalSpecs = "Puissance : 800W\nVitesse : 0-3000 tr/min\nÉnergie d'impact : 2.6 J\nPoids : 2.8 kg",
                    IsActive = true
                },
                
                // Sécurité
                new Product {
                    Description = "Casque de sécurité",
                    Price = 85.00m,
                    CostPrice = 65.00m,
                    CategoryId = categories[5].CategoryId,
                    StockQuantity = 300,
                    UnitOfMeasure = "pièces",
                    TechnicalSpecs = "Norme : EN 397\nMatériau : Polyéthylène\nCouleurs : Jaune, blanc, bleu\nAjustement : 53-61cm",
                    IsActive = true
                },
                new Product {
                    Description = "Gants de travail cuir",
                    Price = 35.00m,
                    CostPrice = 25.00m,
                    CategoryId = categories[5].CategoryId,
                    StockQuantity = 400,
                    UnitOfMeasure = "paires",
                    TechnicalSpecs = "Matériau : Cuir de vache\nTaille : S, M, L, XL\nProtection : Mécanique, chaleur\nNorme : EN 388",
                    IsActive = true
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            base.Seed(context);
        }
    }
} 