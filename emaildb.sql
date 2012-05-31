-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 05 月 29 日 07:08
-- 服务器版本: 5.5.8
-- PHP 版本: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `emaildb`
--

-- --------------------------------------------------------

--
-- 表的结构 `friends`
--

CREATE TABLE IF NOT EXISTS `friends` (
  `UserEmail` varchar(20) NOT NULL,
  `FriEmail` varchar(20) NOT NULL,
  PRIMARY KEY (`UserEmail`,`FriEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `friends`
--


-- --------------------------------------------------------

--
-- 表的结构 `inbox`
--

CREATE TABLE IF NOT EXISTS `inbox` (
  `Addressor` varchar(30) NOT NULL,
  `Addressee` varchar(30) NOT NULL,
  `Title` varchar(30) NOT NULL,
  `Content` text NOT NULL,
  PRIMARY KEY (`Addressor`,`Addressee`,`Title`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `inbox`
--

INSERT INTO `inbox` (`Addressor`, `Addressee`, `Title`, `Content`) VALUES
('940194901@qq.com', 'meili@163.com', 'Hi', '');

-- --------------------------------------------------------

--
-- 表的结构 `outbox`
--

CREATE TABLE IF NOT EXISTS `outbox` (
  `Addressor` varchar(20) NOT NULL,
  `Addressee` varchar(30) NOT NULL,
  `Title` varchar(20) NOT NULL,
  `Content` text NOT NULL,
  PRIMARY KEY (`Addressor`,`Addressee`,`Title`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `outbox`
--


-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `UserName` varchar(20) NOT NULL,
  `Email` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  PRIMARY KEY (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`UserName`, `Email`, `Password`) VALUES
('Tomy', '940194901@qq.com', '123456');
