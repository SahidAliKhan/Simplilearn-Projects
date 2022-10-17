create database  DigitalRetailersDB

use DigitalRetailersDB

create table lapbrands(
brandid int constraint pk_brands primary key,
brandname varchar(20))

create table logintable(
customerid int constraint pk_login primary key,
customername varchar(30))

create table placedorders(
issueid int constraint pk_placedorders primary key,
customerid int constraint fk_logintable foreign key references logintable(customerid),
brandid int constraint fk_lapbrands foreign key references lapbrands(brandid),
orderdate date,
receiveddate date,
comments varchar(20)
)