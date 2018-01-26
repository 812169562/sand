/*
Navicat MySQL Data Transfer

Source Server         : root
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : sand

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2018-01-26 16:18:29
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for dics
-- ----------------------------
DROP TABLE IF EXISTS `dics`;
CREATE TABLE `dics` (
  `Id` varchar(36) NOT NULL COMMENT '编号',
  `Code` varchar(36) DEFAULT NULL COMMENT '代码',
  `TenantId` varchar(36) NOT NULL COMMENT '租户',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 NOT NULL COMMENT '创建者',
  `CreateName` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '创建人',
  `LastUpdateTime` datetime DEFAULT NULL COMMENT '最近更新时间',
  `LastUpdateId` varchar(36) DEFAULT NULL COMMENT '最近更新者',
  `LastUpdateName` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '最近更新人',
  `IsEnable` tinyint(4) NOT NULL COMMENT '是否可用',
  `Name` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '名称',
  `PinYin` varchar(50) DEFAULT NULL COMMENT '拼音简拼',
  `FullPinYin` varchar(150) DEFAULT NULL COMMENT '全拼',
  `Wubi` varchar(80) DEFAULT NULL COMMENT '五笔',
  `RelationShip` varchar(370) DEFAULT NULL COMMENT '关系',
  `Parent` varchar(36) DEFAULT NULL COMMENT '父级',
  `Level` int(11) DEFAULT NULL COMMENT '等级',
  `Sort` int(11) NOT NULL COMMENT '排序',
  `Type` int(11) NOT NULL COMMENT '类型',
  `Status` int(11) NOT NULL COMMENT '状态',
  `Version` tinyblob NOT NULL COMMENT '版本号',
  `IsDeleted` tinyint(4) NOT NULL COMMENT '删除标志',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='字典表';

-- ----------------------------
-- Table structure for tenant
-- ----------------------------
DROP TABLE IF EXISTS `tenant`;
CREATE TABLE `tenant` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '租户',
  `TenantId` varchar(36) NOT NULL COMMENT '租户',
  `TenantName` varchar(80) CHARACTER SET utf8 NOT NULL COMMENT '租户名',
  `TelName` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '联系人',
  `Address` varchar(80) CHARACTER SET utf8 DEFAULT NULL COMMENT '联系地址',
  `TelPhone` varchar(11) NOT NULL COMMENT '联系电话',
  `BusinessCertificate` varchar(36) DEFAULT NULL COMMENT '营业证书',
  `Code` varchar(36) DEFAULT NULL COMMENT '代码',
  `EndTime` datetime DEFAULT NULL COMMENT '结束日期',
  `Type` int(11) NOT NULL COMMENT '类型',
  `Status` int(11) NOT NULL COMMENT '状态',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateId` varchar(36) CHARACTER SET utf8 NOT NULL COMMENT '创建者',
  `CreateName` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '创建人',
  `LastUpdateTime` datetime DEFAULT NULL COMMENT '最近更新时间',
  `LastUpdateId` varchar(36) DEFAULT NULL COMMENT '最近更新者',
  `LastUpdateName` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '最近更新人',
  `Version` char(36) NOT NULL COMMENT '版本号',
  `IsDeleted` tinyint(1) NOT NULL COMMENT '删除标志',
  `IsEnable` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1 COMMENT='租户';
