USE MASTER

IF DB_ID('employees_db') IS NULL
BEGIN
  CREATE DATABASE wallet_app_db
END
go