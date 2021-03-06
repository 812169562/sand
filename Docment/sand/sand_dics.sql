-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: sand
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dics`
--

DROP TABLE IF EXISTS `dics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dics` (
  `Id` varchar(36) NOT NULL COMMENT '编号',
  `Code` varchar(36) DEFAULT NULL COMMENT '代码',
  `TenantId` varchar(36) NOT NULL COMMENT '租户',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `CreateId` varchar(36) NOT NULL COMMENT '创建者',
  `CreateName` varchar(50) DEFAULT NULL COMMENT '创建人',
  `LastUpdateTime` datetime DEFAULT NULL COMMENT '最近更新时间',
  `LastUpdateId` varchar(36) DEFAULT NULL COMMENT '最近更新者',
  `LastUpdateName` varchar(50) DEFAULT NULL COMMENT '最近更新人',
  `IsEnable` tinyint(4) NOT NULL COMMENT '是否可用',
  `Name` varchar(50) NOT NULL COMMENT '名称',
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='字典表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dics`
--

LOCK TABLES `dics` WRITE;
/*!40000 ALTER TABLE `dics` DISABLE KEYS */;
INSERT INTO `dics` VALUES ('08d52c97-a914-8d47-0904-34fc2b823d61','1','5666f36d-5340-44d0-9a88-c61538000f01','2017-11-16 10:13:42','f9262da9-002a-4474-9f6a-d345f46c422e','1','2017-11-16 10:13:42','1','2017/11/16 10:13:43',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'43460d23-5295-4540-b16f-0b91d713a9ad',0),('08d52ca4-3f67-9acd-1780-4e30ae2cf818','1','1da599c4-37f3-4c2c-8a8f-0ca0e5b279a9','2017-11-16 11:43:42','ef83671a-511c-482a-85f5-6e4f5f228b40','1','2017-11-16 11:43:42','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'3f55a9ca-1c74-49fc-892e-7eb339ae4622',0),('08d52ca5-2f4c-4186-553a-3996bcc37b0f','1','0e112619-3a5c-470e-9e8f-c3e54d9d4ecc','2017-11-16 11:50:31','d9d63074-b738-4612-84eb-595d6039568a','1','2017-11-16 11:50:31','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'8f90118b-085c-49ee-8d78-4fe72802f5c5',0),('08d52ca5-89a6-057c-a315-684af5148878','1','2db13280-0046-4631-9b06-2d4a62672c11','2017-11-16 11:53:00','3365ed43-0bba-44c7-8feb-da7109575a68','1','2017-11-16 11:53:00','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'9c41140c-ae1c-4b8c-9a6c-198010332fb4',0),('08d52cd2-7412-67e8-6c2a-bdf7cfdb75ee','1','3f53723d-ac73-480c-9143-1bf9f4594af1','2017-11-16 17:14:12','debe5ba1-a270-4cfb-916b-2e5861e693f1','1','2017-11-16 17:14:12','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'ebd683e7-075a-4d05-873b-ea299fe6c921',0),('08d52cd2-7fe9-d1e2-8e8c-941031b641a3','1','f7c4232e-448a-4162-a080-7b0f483f6d12','2017-11-16 17:14:52','0dce0f64-fa85-4fdb-bc9e-3b482243735d','1','2017-11-16 17:14:52','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'dc1a9fd6-7e94-417a-8b4f-cf11087c35c3',0),('08d52cd2-95cc-4f76-6cd4-93377a25207a','1','f9d4c406-0062-4097-8921-1b7748afc3a4','2017-11-16 17:15:02','d4938e58-264d-4250-9bb9-3ad3caf905d5','1','2017-11-16 17:15:02','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'6e745d51-4afb-453d-b544-34cdd3edbe5d',0),('08d52d59-0838-8c62-9da7-6ec85bb126a8','1','e4b743d1-836a-4ce5-b97e-d8a707bcec6a','2017-11-17 09:17:37','25dcecb7-0910-45cb-8014-b90ef606d17c','1','2017-11-17 09:17:37','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'1b3fd748-8d92-4198-9a8d-49abb77a44d8',0),('08d52d5b-aff7-200e-7d24-14218faf7bbf','1','9277a2aa-bb16-4992-8074-cbd36e652b88','2017-11-17 09:36:56','1f200ef1-b342-4a04-bd40-f982b35fa8ee','1','2017-11-17 09:36:56','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'f61f1d4e-bdf3-4480-b08b-8d94ed6888c4',0),('08d52d5b-f9bf-d44b-de64-e2796ff02243','1','6e801d6e-7fbb-406e-8c69-d89a4af59a28','2017-11-17 09:38:59','a4bd690a-f3b4-4b6f-9c1a-3d5bdb418779','1','2017-11-17 09:38:59','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'2665ba80-1e39-4350-ad51-c16df0fdd3bf',0),('08d52d5c-8bf0-f391-a4ae-afd47b56bfc9','1','4cfd419c-4593-4550-a171-67e0456e7cbd','2017-11-17 09:43:05','b8de2d1d-e732-4330-a052-22a7812cb1b1','1','2017-11-17 09:43:05','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'1f8bd258-6da9-4813-8b3f-9ffb4bcf482a',0),('08d52d5c-cfeb-f280-01d4-0556383da977','1','a757a668-3bb4-4965-891a-09560df31fc4','2017-11-17 09:44:59','da2895c1-2247-4fd4-97e8-a9a0465b92d3','1','2017-11-17 09:44:59','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'7f38ee45-78db-4207-93e2-25814fc06996',0),('08d52d5c-e0b1-b9fd-a947-e310bdf20346','1','ee1619a7-0405-4b1f-8dfc-dbb4160432f0','2017-11-17 09:45:24','102e774a-9f06-4178-9808-262e87314b9b','1','2017-11-17 09:45:24','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'1a5952ef-fff3-46b1-afdf-70d3f1f477d8',0),('08d52d5d-19b6-4e69-b596-fe886ac9c124','1','ca741245-a524-4586-be53-760f96f51361','2017-11-17 09:46:56','dfdf4d62-307e-4778-9d4b-f18f0d679784','1','2017-11-17 09:46:56','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'6e79f837-9001-4093-bc2d-2788441c13d3',0),('08d52d6b-cff8-143d-095c-040c60afa7cb','1','812e1a43-f147-4f26-8e46-0807a2ee48f8','2017-11-17 11:32:21','d81f454d-8afa-4a6f-b95e-4abb74d4cd9c','1','2017-11-17 11:32:21','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'f88f6dc6-d104-44b9-b68d-59cf13071e32',0),('08d52d6e-6dc4-4ce0-90c7-9faf71c5bb8c','1','2d810c2f-f181-4ebe-bcda-70b9bfb8227b','2017-11-17 11:51:05','52cd99d7-4dc3-4e57-a6b8-b23cb4674633','1','2017-11-17 11:51:05','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'c3afa94a-5cc1-430a-8eac-b8dff730e0a3',0),('08d52d95-aa78-0623-c9da-530c84b696cf','1','2e257739-70d6-49e8-9e9d-43c2d58f65bf','2017-11-17 16:31:57','548c630d-88ca-4d0d-8860-d98d37cf706f','1','2017-11-17 16:31:57','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'f64f8244-9bf3-463d-a73b-8f661a72fe08',0),('08d52d95-bb0c-168b-1f59-fa949ce71fc8','1','b80eceb3-9f4b-4275-84e8-4ace3939380a','2017-11-17 16:32:25','a7184dc6-ffec-44b4-8356-9baf342b103d','1','2017-11-17 16:32:25','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'8bd01785-31df-4c90-9611-2aec127d7442',0),('39e2d4c7-4c5c-b254-ddc0-fafe1f20eed8','1','5666f36d-5340-44d0-9a88-c61538000f01','2017-11-16 10:13:42','f9262da9-002a-4474-9f6a-d345f46c422e','1','2017-11-16 02:13:43','1','1',1,'1','1','1',NULL,NULL,NULL,0,0,0,0,'43460d23-5295-4540-b16f-0b91d713a9ad',0);
/*!40000 ALTER TABLE `dics` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-17 17:28:16
