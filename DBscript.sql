CREATE TABLE categories
(
	id				int			primary key		identity(1, 1),
	name		    varchar(50)	not null,
);

CREATE TABLE products
(
	id				int			primary key		identity(1, 1),
	name		    varchar(50)	not null,
	price		    money	not null,
	msrp            money not null,
	description     varchar(max) null,
	image_name1     varchar(255) null,
	image_name2     varchar(255) null,
	image_name3     varchar(255) null,
	categoryId       int  not null,
	quantity        int  not null,
	active_listing  varchar(10)  not null,
	constraint fk_products_caegories foreign key (id) references categories(id),
);

Insert into categories (name) values('LivingRoom');
Insert into categories (name) values('BedRoom');
Insert into categories (name) values('DiningRoom');
Insert into categories (name) values('Kitchen');
Insert into categories (name) values('Babies & Kids');

drop table  products;
drop table  categories;

select * from products;