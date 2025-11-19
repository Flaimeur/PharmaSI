-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost
-- Généré le : lun. 13 oct. 2025 à 22:34
-- Version du serveur : 10.4.28-MariaDB
-- Version de PHP : 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `PharmaSI`
--

-- --------------------------------------------------------

--
-- Structure de la table `Affectation`
--

CREATE TABLE `Affectation` (
  `idEmploye` int(11) NOT NULL,
  `idSecteur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `DelegueRegional`
--

CREATE TABLE `DelegueRegional` (
  `idEmploye` int(11) NOT NULL,
  `role` varchar(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `Employe`
--

CREATE TABLE `Employe` (
  `idEmploye` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `poste` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `dateEmb` date DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Employe`
--

INSERT INTO `Employe` (`idEmploye`, `nom`, `prenom`, `adresse`, `poste`, `email`, `dateEmb`, `telephone`) VALUES
(1, 'Durand', 'Toto', '12 rue Bidon, Paris', 'Visiteur', 'toto@example.com', '2022-03-01', '0600000001'),
(2, 'Martin', 'Alice', '5 av de la République, Lyon', 'Responsable Secteur', 'alice.martin@example.com', '2021-07-12', '0600000002'),
(3, 'Bernard', 'Luc', '8 rue des Fleurs, Lille', 'Délégué Régional', 'luc.bernard@example.com', '2023-01-15', '0600000003'),
(4, 'Petit', 'Nina', '14 bd Pasteur, Marseille', 'Visiteur', 'nina.petit@example.com', '2020-11-05', '0600000004'),
(5, 'Robert', 'Karim', '27 rue Victor Hugo, Bordeaux', 'Responsable Secteur', 'karim.robert@example.com', '2022-06-10', '0600000005'),
(6, 'Richard', 'Emma', '3 rue de la Paix, Nantes', 'Visiteur', 'emma.richard@example.com', '2023-09-08', '0600000006'),
(7, 'Dubois', 'Sami', '19 rue Lafayette, Toulouse', 'Visiteur', 'sami.dubois@example.com', '2024-02-22', '0600000007'),
(8, 'Moreau', 'Lea', '41 rue de la Gare, Nice', 'Responsable Secteur', 'lea.moreau@example.com', '2021-04-30', '0600000008'),
(9, 'Laurent', 'Hugo', '77 rue du Port, Strasbourg', 'Visiteur', 'hugo.laurent@example.com', '2023-07-19', '0600000009'),
(10, 'Simon', 'Clara', '22 avenue Jean Jaurès, Dijon', 'Visiteur', 'clara.simon@example.com', '2022-10-13', '0600000010'),
(11, 'Michel', 'Omar', '18 rue Saint-Pierre, Rouen', 'Délégué Régional', 'omar.michel@example.com', '2021-09-01', '0600000011'),
(12, 'Thomas', 'Lina', '40 chemin Vert, Brest', 'Responsable Secteur', 'lina.thomas@example.com', '2020-05-09', '0600000012'),
(13, 'Lefebvre', 'Yanis', '16 rue du Château, Rennes', 'Visiteur', 'yanis.lefebvre@example.com', '2024-01-12', '0600000013'),
(14, 'Gauthier', 'Sofia', '25 avenue du Parc, Grenoble', 'Visiteur', 'sofia.gauthier@example.com', '2022-07-20', '0600000014'),
(15, 'Chevalier', 'Noah', '33 rue du Marché, Montpellier', 'Délégué Régional', 'noah.chevalier@example.com', '2021-12-25', '0600000015'),
(16, 'Meyer', 'Ines', '9 rue de Provence, Clermont-Ferrand', 'Responsable Secteur', 'ines.meyer@example.com', '2023-05-14', '0600000016'),
(17, 'Nguyen', 'Lucas', '7 rue du Pont, Reims', 'Visiteur', 'lucas.nguyen@example.com', '2022-08-27', '0600000017'),
(18, 'Rousseau', 'Mila', '2 rue de la Liberté, Angers', 'Visiteur', 'mila.rousseau@example.com', '2023-03-03', '0600000018'),
(19, 'Girard', 'Adam', '10 rue Paul Bert, Orléans', 'Responsable Secteur', 'adam.girard@example.com', '2021-01-21', '0600000019'),
(20, 'Garcia', 'Eva', '6 rue des Lilas, Metz', 'Visiteur', 'eva.garcia@example.com', '2024-06-18', '0600000020');

-- --------------------------------------------------------

--
-- Structure de la table `Region`
--

CREATE TABLE `Region` (
  `idRegion` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Region`
--

INSERT INTO `Region` (`idRegion`, `nom`) VALUES
(1, 'Île-de-France'),
(2, 'Auvergne-Rhône-Alpes'),
(3, 'Provence-Alpes-Côte d’Azur'),
(4, 'Occitanie'),
(5, 'Nouvelle-Aquitaine');

-- --------------------------------------------------------

--
-- Structure de la table `ResponsableSecteur`
--

CREATE TABLE `ResponsableSecteur` (
  `idEmploye` int(11) NOT NULL,
  `role` varchar(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `Secteur`
--

CREATE TABLE `Secteur` (
  `idSecteur` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `budget` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `Visiteur`
--

CREATE TABLE `Visiteur` (
  `idEmploye` int(11) NOT NULL,
  `budget` decimal(10,2) DEFAULT NULL,
  `objectif` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Affectation`
--
ALTER TABLE `Affectation`
  ADD PRIMARY KEY (`idEmploye`,`idSecteur`),
  ADD KEY `idSecteur` (`idSecteur`);

--
-- Index pour la table `DelegueRegional`
--
ALTER TABLE `DelegueRegional`
  ADD PRIMARY KEY (`idEmploye`);

--
-- Index pour la table `Employe`
--
ALTER TABLE `Employe`
  ADD PRIMARY KEY (`idEmploye`);

--
-- Index pour la table `Region`
--
ALTER TABLE `Region`
  ADD PRIMARY KEY (`idRegion`);

--
-- Index pour la table `ResponsableSecteur`
--
ALTER TABLE `ResponsableSecteur`
  ADD PRIMARY KEY (`idEmploye`);

--
-- Index pour la table `Secteur`
--
ALTER TABLE `Secteur`
  ADD PRIMARY KEY (`idSecteur`);

--
-- Index pour la table `Visiteur`
--
ALTER TABLE `Visiteur`
  ADD PRIMARY KEY (`idEmploye`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `Employe`
--
ALTER TABLE `Employe`
  MODIFY `idEmploye` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT pour la table `Region`
--
ALTER TABLE `Region`
  MODIFY `idRegion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `Secteur`
--
ALTER TABLE `Secteur`
  MODIFY `idSecteur` int(11) NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `Affectation`
--
ALTER TABLE `Affectation`
  ADD CONSTRAINT `affectation_ibfk_1` FOREIGN KEY (`idEmploye`) REFERENCES `Employe` (`idEmploye`) ON DELETE CASCADE,
  ADD CONSTRAINT `affectation_ibfk_2` FOREIGN KEY (`idSecteur`) REFERENCES `Secteur` (`idSecteur`) ON DELETE CASCADE;

--
-- Contraintes pour la table `DelegueRegional`
--
ALTER TABLE `DelegueRegional`
  ADD CONSTRAINT `delegueregional_ibfk_1` FOREIGN KEY (`idEmploye`) REFERENCES `Employe` (`idEmploye`) ON DELETE CASCADE;

--
-- Contraintes pour la table `ResponsableSecteur`
--
ALTER TABLE `ResponsableSecteur`
  ADD CONSTRAINT `responsablesecteur_ibfk_1` FOREIGN KEY (`idEmploye`) REFERENCES `Employe` (`idEmploye`) ON DELETE CASCADE;

--
-- Contraintes pour la table `Visiteur`
--
ALTER TABLE `Visiteur`
  ADD CONSTRAINT `visiteur_ibfk_1` FOREIGN KEY (`idEmploye`) REFERENCES `Employe` (`idEmploye`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
