-----===PARTS===-----
create table PartCategory(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
)

create table PartSubcategory(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
,PartCategoryId int not null

,constraint FK_PartSubcategory_PartCategory foreign key(PartCategoryId) references PartCategory(Id) on delete cascade
)

create table Part(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
,PartSubcategoryId int not null
--Where to buy?

,constraint FK_Part_PartSubcategory foreign key(PartSubcategoryId) references PartSubcategory(Id) on delete cascade
)

--Part Properties
create table PartPropertyGroup(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
)

create table PartProperty(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
,PartPropertyGroupId int not null

,constraint FK_PartProperty_PartPropertyGroup foreign key(PartPropertyGroupId) references PartPropertyGroup(Id) on delete cascade
)

--Part Property Links
create table Part_PartProperty(
Id int not null identity(1,1) primary key
,PartId int not null
,PartPropertyId int not null

,constraint FK_Part_PartProperty_Part foreign key(PartId) references Part(Id) on delete cascade
,constraint FK_Part_PartProperty_PartProperty foreign key(PartPropertyId) references PartProperty(Id) on delete cascade
)

-----===RC's===-----
create table RCCategory(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
)

create table RCSubcategory(
Id int not null identity(1,1) primary key
,Name varchar(100) not null
,RCCategoryId int not null

,constraint FK_RCSubcategory_RCCategory foreign key(RCCategoryId) references RCCategory(Id) on delete cascade
)

--create table TemplateType(
--Id int not null identity(1,1) primary key
--,Name varchar(100) not null
--)

--create table Template(
--Id int not null identity(1,1) primary key
--,Name varchar(100) not null
--,TypeId int not null
--)

