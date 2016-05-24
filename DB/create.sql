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
	`name` VARCHAR(50) NULL DEFAULT NULL COMMENT '��������',
	`address` VARCHAR(100) NULL DEFAULT NULL COMMENT '������ַ',
	`tel` VARCHAR(50) NULL DEFAULT NULL COMMENT '�����绰',
	`coordinates_longitude` VARCHAR(50) NULL DEFAULT NULL COMMENT '����',
	`coordinates_latitude` VARCHAR(50) NULL DEFAULT NULL COMMENT 'γ��',
	`createdate` DATETIME NULL DEFAULT NULL COMMENT '����ʱ��',
	`businesstime_start` VARCHAR(50) NULL DEFAULT NULL COMMENT 'Ӫҵ��ʼʱ��',
	`businesstime_end` VARCHAR(50) NULL DEFAULT NULL COMMENT 'Ӫҵ��ֹʱ��',
	`deliverytime` VARCHAR(50) NULL DEFAULT NULL COMMENT '�Ͳ���ʼʱ��',
	`business_status` SMALLINT(6) NULL DEFAULT '0' COMMENT 'Ӫҵ״̬',
	PRIMARY KEY (`id`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=123
;
