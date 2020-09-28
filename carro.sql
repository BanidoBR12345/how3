-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 28-Set-2020 às 19:15
-- Versão do servidor: 10.4.14-MariaDB
-- versão do PHP: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `locadora`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `carro`
--

CREATE TABLE `carro` (
  `idCarro` int(11) NOT NULL,
  `nomeCarro` varchar(50) NOT NULL,
  `anoCarro` int(4) NOT NULL,
  `corCarro` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `carro`
--

INSERT INTO `carro` (`idCarro`, `nomeCarro`, `anoCarro`, `corCarro`) VALUES
(6, 'celta', 2005, 'prata'),
(7, 'palio', 2008, 'azul'),
(8, 'corsa', 1998, 'preto'),
(9, 'palio weekend', 2013, 'verde'),
(10, 'kia soul', 2010, 'branco'),
(11, 'paliozada', 6666, 'black'),
(12, 'malibu', 2008, 'preta'),
(13, 'celta', 2009, 'rosa'),
(15, 'l,oklkl', 2002, 'jhbbhjhbj'),
(16, 'up', 2015, 'branco'),
(17, 'celta', 2000, 'rosinha'),
(18, 'palio', 2000, 'azul');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `carro`
--
ALTER TABLE `carro`
  ADD PRIMARY KEY (`idCarro`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `carro`
--
ALTER TABLE `carro`
  MODIFY `idCarro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
