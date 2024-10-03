-- Table: public."Users"

-- DROP TABLE public."Users";

CREATE TABLE public."Users"
(
  "Id" integer NOT NULL DEFAULT nextval('"Users_Id_seq"'::regclass),
  "Login" character varying(100),
  "Password" character varying(36)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public."Users"
  OWNER TO postgres;
ALTER TABLE public."Users" ALTER COLUMN "Id" SET STATISTICS 0;
ALTER TABLE public."Users" ALTER COLUMN "Login" SET STATISTICS 0;
ALTER TABLE public."Users" ALTER COLUMN "Password" SET STATISTICS 0;

