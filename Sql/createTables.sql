USE MASTER

IF DB_ID('account_db') IS NULL
BEGIN
  CREATE DATABASE account_db
END
go

IF DB_ID('event_account_db') IS NULL
BEGIN
  CREATE DATABASE event_account_db
END
go