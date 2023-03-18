-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 18, 2023 at 04:28 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `myapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `administrator`
--

CREATE TABLE `administrator` (
  `userName` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `createdBy` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `createdTime` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Dumping data for table `administrator`
--

INSERT INTO `administrator` (`userName`, `password`, `createdBy`, `createdTime`) VALUES
('admin', 'adm', 'Administrator', '2023-02-16 14:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(11) NOT NULL COMMENT 'mã nhân viên',
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'tên nhân viên',
  `birthday` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'ngày sinh',
  `address` text CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'địa chỉ',
  `phone` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'số điện thoại',
  `email` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'địa chỉ email',
  `accountPassword` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'mật khẩu tài khoản',
  `accountLevel` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'cấp độ tài khoản',
  `createdBy` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'người tạo thông tin',
  `createdTime` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'ngày tạo thông tin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `name`, `birthday`, `address`, `phone`, `email`, `accountPassword`, `accountLevel`, `createdBy`, `createdTime`) VALUES
(1000, 'sa', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-16 14:02:00'),
(1001, 'AccountantManager', NULL, NULL, NULL, NULL, '11', '1', 'Administrator', '2023-02-16 14:05:00'),
(1002, 'sa2', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-18 15:02:00'),
(1003, 'sa3', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-18 14:05:00'),
(1004, 'sa4', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-16 14:04:00'),
(1005, 'sa5', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-18 15:05:00'),
(1006, 'sa6', NULL, NULL, NULL, NULL, '11', '2', 'Administrator', '2023-02-18 14:06:00'),
(1014, 'SalesManager', NULL, NULL, NULL, NULL, '11', '1', 'Administrator', '2023-02-16 14:14:00'),
(1015, 'ITManager', NULL, NULL, NULL, NULL, '11', '1', 'Administrator', '2023-02-16 15:14:00'),
(9999, 'president', NULL, NULL, NULL, NULL, '11', '0', 'Administrator', '2023-02-16 14:59:00');

-- --------------------------------------------------------

--
-- Table structure for table `management`
--

CREATE TABLE `management` (
  `managerID` int(11) NOT NULL COMMENT 'mã quản lý',
  `employeeID` int(11) NOT NULL COMMENT 'mã nhân viên',
  `department` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'bộ phận',
  `createdBy` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'người tạo thông tin',
  `createdTime` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'ngày tạo thông tin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Dumping data for table `management`
--

INSERT INTO `management` (`managerID`, `employeeID`, `department`, `createdBy`, `createdTime`) VALUES
(1001, 1000, 'Accountant', 'Administrator', '2023-02-16 14:05:00'),
(1014, 1002, 'Sales', 'Administrator', '2023-02-16 14:06:00'),
(1014, 1003, 'Sales', 'Administrator', '2023-02-16 14:05:00'),
(1014, 1004, 'Sales', 'Administrator', '2023-02-16 14:06:00'),
(1015, 1005, 'IT', 'Administrator', '2023-02-16 14:02:00'),
(1015, 1006, 'IT', 'Administrator', '2023-02-16 14:06:00'),
(9999, 1001, 'Office', 'Administrator', '2023-02-16 14:05:00'),
(9999, 1014, 'Office', 'Administrator', '2023-02-16 14:02:00'),
(9999, 1015, 'Office', 'Administrator', '2023-02-16 14:06:00');

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `id` int(11) NOT NULL COMMENT 'mã quản lý',
  `name` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'tên quản lý',
  `position` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'chức vụ',
  `createdBy` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'người tạo thông tin',
  `createdTime` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'ngày tạo thông tin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`id`, `name`, `position`, `createdBy`, `createdTime`) VALUES
(1001, 'AccountantManager', 'Manager', 'Administrator', '2023-02-16 14:48:00'),
(1014, 'SalesManager', 'Manager', 'Administrator', '2023-02-16 14:38:00'),
(1015, 'ITManager', 'Manager', 'Administrator', '2023-02-16 14:38:00'),
(9999, 'President', 'President', 'Administrator', '2023-02-16 14:58:00');

-- --------------------------------------------------------

--
-- Table structure for table `timekeeping`
--

CREATE TABLE `timekeeping` (
  `id` int(11) NOT NULL COMMENT 'mã chấm công',
  `employeeID` int(11) DEFAULT NULL COMMENT 'mã nhân viên',
  `date` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'ngà chấm công',
  `timeIn` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'giờ bắt đầu',
  `timeOut` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'giờ kết thùc',
  `createdBy` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'người tạo thông tin',
  `modifiedBy` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'người sửa thông tin'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='thông tin chấm công';

--
-- Indexes for dumped tables
--

--
-- Indexes for table `administrator`
--
ALTER TABLE `administrator`
  ADD PRIMARY KEY (`userName`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `management`
--
ALTER TABLE `management`
  ADD PRIMARY KEY (`managerID`,`employeeID`) USING BTREE,
  ADD KEY `managerID` (`managerID`),
  ADD KEY `employeeID` (`employeeID`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Indexes for table `timekeeping`
--
ALTER TABLE `timekeeping`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD KEY `employeeID` (`employeeID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `management`
--
ALTER TABLE `management`
  ADD CONSTRAINT `fk_employee_management` FOREIGN KEY (`employeeID`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_manager_management` FOREIGN KEY (`managerID`) REFERENCES `manager` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `timekeeping`
--
ALTER TABLE `timekeeping`
  ADD CONSTRAINT `fk_employee_timekeeping` FOREIGN KEY (`employeeID`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
