-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 14 日 07:47
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
-- 表的结构 `linkman`
--

CREATE TABLE IF NOT EXISTS `linkman` (
  `LinkmanId` varchar(40) NOT NULL,
  `Sender` varchar(20) NOT NULL,
  `Receiver` varchar(20) NOT NULL,
  PRIMARY KEY (`Sender`,`Receiver`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `linkman`
--

INSERT INTO `linkman` (`LinkmanId`, `Sender`, `Receiver`) VALUES
('940194901@qq.comjanisa@qq.com', '940194901@qq.com', 'janisa@qq.com'),
('janisa@qq.com940194901@qq.com', 'janisa@qq.com', '940194901@qq.com'),
('janisa@qq.commary@163.com', 'janisa@qq.com', 'mary@163.com'),
('janisa@qq.comyounger@sina.com', 'janisa@qq.com', 'younger@sina.com'),
('mary@163.comjanisa@qq.com', 'mary@163.com', 'janisa@qq.com'),
('mary@163.comyounger@sina.com', 'mary@163.com', 'younger@sina.com'),
('younger@sina.comjanisa@qq.com', 'younger@sina.com', 'janisa@qq.com'),
('younger@sina.commary@163.com', 'younger@sina.com', 'mary@163.com');

-- --------------------------------------------------------

--
-- 表的结构 `messageinbox`
--

CREATE TABLE IF NOT EXISTS `messageinbox` (
  `MessageinId` varchar(40) NOT NULL,
  `Sender` varchar(20) NOT NULL,
  `Receiver` varchar(20) NOT NULL,
  `Topic` varchar(20) NOT NULL,
  `Content` text NOT NULL,
  PRIMARY KEY (`MessageinId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `messageinbox`
--

INSERT INTO `messageinbox` (`MessageinId`, `Sender`, `Receiver`, `Topic`, `Content`) VALUES
('2012/6/14 13:45:53', 'janisa@qq.com', '940194901@qq.com', 'phpmyadmin', 'phpmyadmin'),
('2012/6/14 1:12:27', 'janisa@qq.com', 'mary@163.com', '1234', '12345'),
('2012/6/14 1:17:01', 'younger@sina.com', 'janisa@qq.com', 'test', 'test'),
('2012/6/14 1:17:24', 'younger@sina.com', 'mary@163.com', 'hello', 'hello!'),
('2012/6/14 1:18:47', 'mary@163.com', 'younger@sina.com', 'heihei', '敏捷软件开发'),
('2012/6/14 1:19:34', 'mary@163.com', 'janisa@qq.com', 'welcome', '数据库'),
('2012/6/14 1:20:30', 'janisa@qq.com', 'younger@sina.com', 'XAMPP', '显示');

-- --------------------------------------------------------

--
-- 表的结构 `messageoutbox`
--

CREATE TABLE IF NOT EXISTS `messageoutbox` (
  `MessageoutId` varchar(40) NOT NULL,
  `Sender` varchar(20) NOT NULL,
  `Receiver` varchar(20) NOT NULL,
  `Topic` varchar(20) NOT NULL,
  `Content` text NOT NULL,
  PRIMARY KEY (`MessageoutId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `messageoutbox`
--

INSERT INTO `messageoutbox` (`MessageoutId`, `Sender`, `Receiver`, `Topic`, `Content`) VALUES
('2012/6/14 13:45:53', 'janisa@qq.com', '940194901@qq.com', 'phpmyadmin', 'phpmyadmin'),
('2012/6/14 1:12:27', 'janisa@qq.com', 'mary@163.com', '1234', '12345'),
('2012/6/14 1:17:01', 'younger@sina.com', 'janisa@qq.com', 'test', 'test'),
('2012/6/14 1:17:24', 'younger@sina.com', 'mary@163.com', 'hello', 'hello!'),
('2012/6/14 1:18:47', 'mary@163.com', 'younger@sina.com', 'heihei', '敏捷软件开发'),
('2012/6/14 1:19:34', 'mary@163.com', 'janisa@qq.com', 'welcome', '数据库'),
('2012/6/14 1:20:30', 'janisa@qq.com', 'younger@sina.com', 'XAMPP', '显示');

-- --------------------------------------------------------

--
-- 表的结构 `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `Email` varchar(20) NOT NULL,
  `PassWord` varchar(20) NOT NULL,
  PRIMARY KEY (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `user`
--

INSERT INTO `user` (`Email`, `PassWord`) VALUES
('940194901@qq.com', '123'),
('janisa@qq.com', '12345'),
('mary@163.com', '12345'),
('younger@sina.com', '12345');
