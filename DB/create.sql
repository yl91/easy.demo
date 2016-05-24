CREATE TABLE `db_version` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`from_version` INT(11) NOT NULL,
	`current_version` INT(11) NOT NULL,
	`last_update_datetime` DATETIME NOT NULL,
	PRIMARY KEY (`id`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

CREATE TABLE `supplier` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`name` VARCHAR(50) NULL DEFAULT NULL COMMENT '餐厅名称',
	`address` VARCHAR(100) NULL DEFAULT NULL COMMENT '餐厅地址',
	`tel` VARCHAR(50) NULL DEFAULT NULL COMMENT '餐厅电话',
	`coordinates_longitude` VARCHAR(50) NULL DEFAULT NULL COMMENT '经度',
	`coordinates_latitude` VARCHAR(50) NULL DEFAULT NULL COMMENT '纬度',
	`createdate` DATETIME NULL DEFAULT NULL COMMENT '创建时间',
	`businesstime_start` VARCHAR(50) NULL DEFAULT NULL COMMENT '营业起始时间',
	`businesstime_end` VARCHAR(50) NULL DEFAULT NULL COMMENT '营业终止时间',
	`deliverytime` VARCHAR(50) NULL DEFAULT NULL COMMENT '送餐起始时间',
	`business_status` SMALLINT(6) NULL DEFAULT '0' COMMENT '营业状态',
	PRIMARY KEY (`id`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=123
;
