-- MySQL Script generated by MySQL Workbench
-- Tue Mar 24 10:47:26 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema revues
-- -----------------------------------------------------
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`revue`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`revue` ;

CREATE TABLE IF NOT EXISTS `mydb`.`revue` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `periodicite` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`numero`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`numero` ;

CREATE TABLE IF NOT EXISTS `mydb`.`numero` (
  `nombre` INT NOT NULL,
  `annee` INT NOT NULL,
  `nbpages` INT NULL,
  `revue_id` INT NOT NULL,
  PRIMARY KEY (`nombre`, `annee`, `revue_id`),
  INDEX `fk_numero_revue1_idx` (`revue_id` ASC)   ,
  CONSTRAINT `fk_numero_revue1`
    FOREIGN KEY (`revue_id`)
    REFERENCES `mydb`.`revue` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`article`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`article` ;

CREATE TABLE IF NOT EXISTS `mydb`.`article` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `titre` VARCHAR(45) NULL,
  `contenu` VARCHAR(45) NULL,
  `article_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_article_article1_idx` (`article_id` ASC)   ,
  CONSTRAINT `fk_article_article1`
    FOREIGN KEY (`article_id`)
    REFERENCES `mydb`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`auteur`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`auteur` ;

CREATE TABLE IF NOT EXISTS `mydb`.`auteur` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `prenom` VARCHAR(45) NULL,
  `mail` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ecrire`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`ecrire` ;

CREATE TABLE IF NOT EXISTS `mydb`.`ecrire` (
  `article_id` INT NOT NULL,
  `auteur_id` INT NOT NULL,
  PRIMARY KEY (`article_id`, `auteur_id`),
  INDEX `fk_article_has_auteur_auteur1_idx` (`auteur_id` ASC)   ,
  INDEX `fk_article_has_auteur_article_idx` (`article_id` ASC)   ,
  CONSTRAINT `fk_article_has_auteur_article`
    FOREIGN KEY (`article_id`)
    REFERENCES `mydb`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_article_has_auteur_auteur1`
    FOREIGN KEY (`auteur_id`)
    REFERENCES `mydb`.`auteur` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`contient`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`contient` ;

CREATE TABLE IF NOT EXISTS `mydb`.`contient` (
  `numero_nombre` INT NOT NULL,
  `numero_annee` INT NOT NULL,
  `article_id` INT NOT NULL,
  `pagedebut` INT NULL,
  `pagefin` INT NULL,
  PRIMARY KEY (`numero_nombre`, `numero_annee`, `article_id`),
  INDEX `fk_numero_has_article_article1_idx` (`article_id` ASC)   ,
  INDEX `fk_numero_has_article_numero1_idx` (`numero_nombre` ASC, `numero_annee` ASC)   ,
  CONSTRAINT `fk_numero_has_article_numero1`
    FOREIGN KEY (`numero_nombre` , `numero_annee`)
    REFERENCES `mydb`.`numero` (`nombre` , `annee`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_numero_has_article_article1`
    FOREIGN KEY (`article_id`)
    REFERENCES `mydb`.`article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
