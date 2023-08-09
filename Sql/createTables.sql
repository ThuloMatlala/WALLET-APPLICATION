USE MASTER

IF DB_ID('account_db') IS NULL
BEGIN
  CREATE DATABASE account_db
END
go

IF DB_ID('user_auth_db') IS NULL
BEGIN
  CREATE DATABASE user_auth_db
END
go