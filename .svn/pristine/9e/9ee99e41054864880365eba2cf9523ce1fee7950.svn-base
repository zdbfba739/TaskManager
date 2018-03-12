/*
Navicat MySQL Data Transfer

Source Server         : ceshi
Source Server Version : 50625
Source Host           : 192.168.1.33:3306
Source Database       : dyd_bs_task

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-01-07 11:51:05
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for tb_category
-- ----------------------------
DROP TABLE IF EXISTS `tb_category`;
CREATE TABLE `tb_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(25) COLLATE utf8_bin DEFAULT NULL,
  `categorycreatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_command
-- ----------------------------
DROP TABLE IF EXISTS `tb_command`;
CREATE TABLE `tb_command` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `command` varchar(400) COLLATE utf8_bin DEFAULT NULL,
  `commandname` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `commandstate` tinyint(4) DEFAULT NULL,
  `taskid` int(11) DEFAULT NULL,
  `nodeid` int(11) DEFAULT NULL,
  `commandcreatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_config
-- ----------------------------
DROP TABLE IF EXISTS `tb_config`;
CREATE TABLE `tb_config` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `configkey` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `configvalue` varchar(8000) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(8000) COLLATE utf8_bin DEFAULT NULL,
  `lastupdatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_error
-- ----------------------------
DROP TABLE IF EXISTS `tb_error`;
CREATE TABLE `tb_error` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msg` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `errortype` tinyint(4) DEFAULT NULL,
  `errorcreatetime` datetime DEFAULT NULL,
  `taskid` int(11) DEFAULT NULL,
  `nodeid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_log
-- ----------------------------
DROP TABLE IF EXISTS `tb_log`;
CREATE TABLE `tb_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msg` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `logtype` tinyint(4) DEFAULT NULL,
  `logcreatetime` datetime DEFAULT NULL,
  `taskid` int(11) DEFAULT NULL,
  `nodeid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_node
-- ----------------------------
DROP TABLE IF EXISTS `tb_node`;
CREATE TABLE `tb_node` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nodename` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `nodecreatetime` datetime DEFAULT NULL,
  `nodeip` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `nodelastupdatetime` datetime DEFAULT NULL,
  `ifcheckstate` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_performance
-- ----------------------------
DROP TABLE IF EXISTS `tb_performance`;
CREATE TABLE `tb_performance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nodeid` int(11) DEFAULT NULL,
  `taskid` int(11) DEFAULT NULL,
  `cpu` float DEFAULT NULL,
  `memory` float DEFAULT NULL,
  `installdirsize` float DEFAULT NULL,
  `lastupdatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_task
-- ----------------------------
DROP TABLE IF EXISTS `tb_task`;
CREATE TABLE `tb_task` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `taskname` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `categoryid` int(11) DEFAULT NULL,
  `nodeid` int(11) DEFAULT NULL,
  `taskcreatetime` datetime DEFAULT NULL,
  `taskupdatetime` datetime DEFAULT NULL,
  `tasklaststarttime` datetime DEFAULT NULL,
  `tasklastendtime` datetime DEFAULT NULL,
  `tasklasterrortime` datetime DEFAULT NULL,
  `taskerrorcount` int(11) DEFAULT NULL,
  `taskruncount` bigint(20) DEFAULT NULL,
  `taskcreateuserid` int(11) DEFAULT NULL,
  `taskstate` tinyint(4) DEFAULT NULL,
  `taskversion` int(11) DEFAULT NULL,
  `taskappconfigjson` varchar(1000) COLLATE utf8_bin DEFAULT NULL,
  `taskcron` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `taskmainclassdllfilename` varchar(60) COLLATE utf8_bin DEFAULT NULL,
  `taskmainclassnamespace` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `taskremark` varchar(5000) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_tempdata
-- ----------------------------
DROP TABLE IF EXISTS `tb_tempdata`;
CREATE TABLE `tb_tempdata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `taskid` int(11) DEFAULT NULL,
  `tempdatajson` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `tempdatalastupdatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_user
-- ----------------------------
DROP TABLE IF EXISTS `tb_user`;
CREATE TABLE `tb_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userstaffno` varchar(25) COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(25) COLLATE utf8_bin DEFAULT NULL,
  `userrole` tinyint(4) DEFAULT NULL,
  `usercreatetime` datetime DEFAULT NULL,
  `usertel` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `useremail` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ----------------------------
-- Table structure for tb_version
-- ----------------------------
DROP TABLE IF EXISTS `tb_version`;
CREATE TABLE `tb_version` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `taskid` int(11) DEFAULT NULL,
  `version` int(11) DEFAULT NULL,
  `versioncreatetime` datetime DEFAULT NULL,
  `zipfile` longblob,
  `zipfilename` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;


INSERT INTO `tb_user` VALUES ('1', 'admin', '系统管理员', '0', '2016-05-23 09:41:48', '', '');
