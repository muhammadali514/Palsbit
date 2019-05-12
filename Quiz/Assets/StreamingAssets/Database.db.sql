BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "GeneralCategories" (
	"CAT_ID"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"Cat_name"	TEXT
);
CREATE TABLE IF NOT EXISTS "Academic_Category" (
	"CAT_ID"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"Cat_name"	TEXT
);
INSERT INTO "GeneralCategories" VALUES (1,'Mixed');
INSERT INTO "GeneralCategories" VALUES (2,'Mixed');
INSERT INTO "GeneralCategories" VALUES (3,'Mixed');
INSERT INTO "GeneralCategories" VALUES (4,'Mixed');
INSERT INTO "GeneralCategories" VALUES (5,'Mixed');
INSERT INTO "GeneralCategories" VALUES (6,'Mixed');
INSERT INTO "GeneralCategories" VALUES (7,'Mixed');
INSERT INTO "GeneralCategories" VALUES (8,'Mixed');
INSERT INTO "GeneralCategories" VALUES (9,'Mixed');
INSERT INTO "GeneralCategories" VALUES (10,'Mixed');
INSERT INTO "GeneralCategories" VALUES (11,'Mixed');
INSERT INTO "Academic_Category" VALUES (5,'Grammer');
INSERT INTO "Academic_Category" VALUES (6,'Grammer');
INSERT INTO "Academic_Category" VALUES (7,'Grammer');
INSERT INTO "Academic_Category" VALUES (8,'Grammer');
INSERT INTO "Academic_Category" VALUES (9,'English');
INSERT INTO "Academic_Category" VALUES (10,'Maths');
INSERT INTO "Academic_Category" VALUES (11,'Science');
INSERT INTO "Academic_Category" VALUES (12,'English');
INSERT INTO "Academic_Category" VALUES (13,'Maths');
INSERT INTO "Academic_Category" VALUES (14,'Science');
COMMIT;
