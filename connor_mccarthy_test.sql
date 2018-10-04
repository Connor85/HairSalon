-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Oct 04, 2018 at 03:05 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `connor_mccarthy_test`
--
CREATE DATABASE IF NOT EXISTS `connor_mccarthy_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `connor_mccarthy_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(32) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 13),
(2, 2, 13),
(3, 3, 17),
(4, 4, 17),
(5, 5, 21),
(6, 6, 21),
(7, 7, 25),
(8, 8, 25),
(9, 9, 29),
(10, 10, 29),
(11, 11, 33),
(12, 12, 33),
(13, 13, 37),
(14, 14, 37),
(15, 15, 41),
(16, 16, 41),
(17, 17, 45),
(18, 18, 45),
(19, 19, 49),
(20, 20, 49),
(21, 21, 53),
(22, 22, 53),
(23, 23, 57),
(24, 24, 57),
(25, 25, 62),
(26, 26, 62),
(27, 27, 67),
(28, 28, 67),
(29, 29, 71),
(30, 30, 71),
(31, 31, 75),
(32, 32, 75),
(33, 33, 79),
(34, 34, 79),
(35, 35, 84),
(36, 36, 84),
(37, 37, 89),
(38, 38, 89),
(39, 39, 93),
(40, 40, 93),
(41, 41, 95),
(42, 42, 95),
(43, 43, 99),
(44, 45, 101),
(45, 46, 101),
(46, 47, 105),
(47, 49, 108),
(48, 50, 108),
(49, 51, 112),
(50, 53, 115),
(51, 54, 115),
(52, 55, 119),
(53, 57, 122),
(54, 58, 122),
(55, 59, 126),
(56, 62, 130),
(57, 63, 130),
(58, 64, 134),
(59, 66, 137),
(60, 67, 137),
(61, 68, 141),
(62, 70, 144),
(63, 71, 144),
(64, 72, 148),
(65, 74, 151),
(66, 75, 151),
(67, 76, 155),
(68, 78, 158),
(69, 79, 158),
(70, 80, 162),
(71, 82, 165),
(72, 83, 165),
(73, 84, 169),
(74, 86, 172),
(75, 87, 172),
(76, 88, 176),
(77, 90, 179),
(78, 91, 179),
(79, 92, 183),
(80, 94, 186),
(81, 95, 186),
(82, 96, 190),
(83, 98, 193),
(84, 99, 193),
(85, 100, 197),
(86, 102, 200),
(87, 103, 200),
(88, 104, 204),
(89, 106, 207),
(90, 107, 207),
(91, 108, 211),
(92, 110, 214),
(93, 111, 214),
(94, 112, 218);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL,
  `hire_date` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `stylists_clients`
--

CREATE TABLE `stylists_clients` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=95;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=219;

--
-- AUTO_INCREMENT for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
