-- MySQL Script generated by MySQL Workbench
-- Tue Mar 24 17:51:00 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema revues
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `revues` ;

-- -----------------------------------------------------
-- Schema revues
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `revues` DEFAULT CHARACTER SET utf8 ;
USE `revues` ;

-- -----------------------------------------------------
-- Table `revues`.`revue`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`revue` ;

CREATE TABLE IF NOT EXISTS `revues`.`revue` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `periodicite` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`numero`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`numero` ;

CREATE TABLE IF NOT EXISTS `revues`.`numero` (
  `nombre` INT NOT NULL,
  `annee` INT NOT NULL,
  `nbpages` INT NULL,
  `revue_id` INT NOT NULL,
  `id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`),
  INDEX `fk_numero_revue1_idx` (`revue_id` ASC)  ,
  CONSTRAINT `fk_numero_revue1`
    FOREIGN KEY (`revue_id`)
    REFERENCES `revues`.`revue` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`article`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`article` ;

CREATE TABLE IF NOT EXISTS `revues`.`article` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `titre` VARCHAR(45) NULL,
  `contenu` VARCHAR(45) NULL,
  `article_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_article_article1_idx` (`article_id` ASC)  ,
  CONSTRAINT `fk_article_article1`
    FOREIGN KEY (`article_id`)
    REFERENCES `revues`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`auteur`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`auteur` ;

CREATE TABLE IF NOT EXISTS `revues`.`auteur` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `prenom` VARCHAR(45) NULL,
  `mail` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`ecrire`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`ecrire` ;

CREATE TABLE IF NOT EXISTS `revues`.`ecrire` (
  `article_id` INT NOT NULL,
  `auteur_id` INT NOT NULL,
  PRIMARY KEY (`article_id`, `auteur_id`),
  INDEX `fk_article_has_auteur_auteur1_idx` (`auteur_id` ASC)  ,
  INDEX `fk_article_has_auteur_article_idx` (`article_id` ASC)  ,
  CONSTRAINT `fk_article_has_auteur_article`
    FOREIGN KEY (`article_id`)
    REFERENCES `revues`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_article_has_auteur_auteur1`
    FOREIGN KEY (`auteur_id`)
    REFERENCES `revues`.`auteur` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`numero_has_contient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`numero_has_contient` ;

CREATE TABLE IF NOT EXISTS `revues`.`numero_has_contient` (
  `numero_id` INT NOT NULL,
  `contient_article_id` INT NOT NULL,
  PRIMARY KEY (`numero_id`, `contient_article_id`),
  INDEX `fk_numero_has_contient_numero1_idx` (`numero_id` ASC)  ,
  CONSTRAINT `fk_numero_has_contient_numero1`
    FOREIGN KEY (`numero_id`)
    REFERENCES `revues`.`numero` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `revues`.`contient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `revues`.`contient` ;

CREATE TABLE IF NOT EXISTS `revues`.`contient` (
  `numero_id` INT NOT NULL,
  `article_id` INT NOT NULL,
  `id` INT NOT NULL AUTO_INCREMENT,
  `page_debut` INT NULL,
  `page_fin` INT NULL,
  INDEX `fk_numero_has_article_article2_idx` (`article_id` ASC)  ,
  INDEX `fk_numero_has_article_numero1_idx` (`numero_id` ASC)  ,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_numero_has_article_numero1`
    FOREIGN KEY (`numero_id`)
    REFERENCES `revues`.`numero` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_numero_has_article_article2`
    FOREIGN KEY (`article_id`)
    REFERENCES `revues`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
