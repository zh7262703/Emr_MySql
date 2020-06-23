
/* ============================================================ */
/*   TABLE: T_AUDITCONFIG  会诊审核                               */
/* ============================================================ */
CREATE TABLE "T_AUDITCONFIG" 
(
  "XH" NUMBER(12,0) NOT NULL ENABLE, 
  "YSBM" VARCHAR2(32),  
  "YSMC" VARCHAR2(128),  
  "KSBM" VARCHAR2(20), 
  "KSMC" VARCHAR2(128), 
  "SJKS" VARCHAR2(20),    
  "SFYX" VARCHAR2(8),     
   CONSTRAINT "PK_T_AUDITCONFIG" PRIMARY KEY("XH")
 );  
 
 
ALTER TABLE T_CONSULTAION_APPLY ADD  "ISAUDIT" varchar2(4); --0,无需审核，1需要审核，2已审核
 
 
/* ============================================================ */
/*   序列与触发器，     T_AUDITCONFIG自增字段XH                    */
/* ============================================================ */ 
CREATE SEQUENCE T_AUDITCONFIG_SEQUENCE
MINVALUE 1
MAXVALUE 9999999999999999999999999999
START WITH 1
INCREMENT BY 1
CACHE 20;

CREATE OR REPLACE TRIGGER T_AUDITCONFIG_XH
  BEFORE INSERT ON T_AUDITCONFIG 
  FOR EACH ROW
DECLARE
BEGIN
  SELECT T_AUDITCONFIG_SEQUENCE.NEXTVAL INTO:NEW.XH FROM DUAL;
END T_AUDITCONFIG_XH;

