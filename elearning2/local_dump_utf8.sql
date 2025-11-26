--
-- PostgreSQL database dump
--

\restrict gsbnNBDQIffE2ZknPzDicgSk9CZWsoc779dmHfy933pLdMKgfg2uwcGhqSglPoF

-- Dumped from database version 16.10 (Debian 16.10-1.pgdg13+1)
-- Dumped by pg_dump version 16.10 (Debian 16.10-1.pgdg13+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Certificates; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Certificates" (
    "Id" uuid NOT NULL,
    "StudentId" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "StudentId1" uuid
);


ALTER TABLE public."Certificates" OWNER TO elearning2user;

--
-- Name: Courses; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Courses" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "TeacherId" uuid NOT NULL
);


ALTER TABLE public."Courses" OWNER TO elearning2user;

--
-- Name: Enrollments; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Enrollments" (
    "Id" uuid NOT NULL,
    "StudentId" uuid NOT NULL,
    "CourseId" uuid NOT NULL,
    "EnrolledAt" timestamp with time zone NOT NULL
);


ALTER TABLE public."Enrollments" OWNER TO elearning2user;

--
-- Name: Lessons; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Lessons" (
    "Id" uuid NOT NULL,
    "CourseId" uuid NOT NULL,
    "Title" text NOT NULL,
    "Content" text NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL
);


ALTER TABLE public."Lessons" OWNER TO elearning2user;

--
-- Name: Students; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Students" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "FullName" text NOT NULL,
    "Bio" text,
    "AvatarUrl" text
);


ALTER TABLE public."Students" OWNER TO elearning2user;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Username" text NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "Role" text NOT NULL,
    "RefreshToken" text,
    "RefreshTokenExpiresAt" timestamp with time zone,
    "RefreshTokenRevokedAt" timestamp with time zone,
    "CurrentJwtId" text
);


ALTER TABLE public."Users" OWNER TO elearning2user;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: elearning2user
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO elearning2user;

--
-- Data for Name: Certificates; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Certificates" ("Id", "StudentId", "Title", "Description", "StudentId1") FROM stdin;
\.


--
-- Data for Name: Courses; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Courses" ("Id", "Title", "Description", "CreatedAt", "TeacherId") FROM stdin;
1e20a7d2-58d8-49e3-a637-3eb00178c16f	Cybersecurity	hacking ethically	2025-11-24 05:55:00+00	019aa3c2-c480-7a3d-a562-15008c505312
\.


--
-- Data for Name: Enrollments; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Enrollments" ("Id", "StudentId", "CourseId", "EnrolledAt") FROM stdin;
\.


--
-- Data for Name: Lessons; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Lessons" ("Id", "CourseId", "Title", "Content", "CreatedAt") FROM stdin;
\.


--
-- Data for Name: Students; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Students" ("Id", "UserId", "FullName", "Bio", "AvatarUrl") FROM stdin;
1e20a7d2-58d8-49e3-a637-3eb00179d26c	019aa380-c0bb-7f91-9caf-df4231fa723c	John	bruhy	\N
\.


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."Users" ("Id", "Username", "Email", "PasswordHash", "Role", "RefreshToken", "RefreshTokenExpiresAt", "RefreshTokenRevokedAt", "CurrentJwtId") FROM stdin;
019aa362-4a3e-7112-9787-6cc3127f033d	admin	admin@example.com	$2a$11$d1P9f2t5Lo0ernVm8OczOeRTUmzjqZBGsuIe1WoeWAd48wPbKqhz2	Admin	d12CNN9aKTM90JgCLyhKhtnSO1l2a3HpITyY7I_NEjHVg_nrsZmuDscqBYnIiPzHa_5RHaBWQA0GsDkMhhn4ug	2025-12-05 00:12:31.589696+00	\N	e8a48f97-2bf7-4587-b814-6e60f731a409
019aa380-c0bb-7f91-9caf-df4231fa723c	caleb	caleb@example.com	$2a$11$5LxItzdT4rSFldaLeosAd.cuXF000Pbs3mKyzDQv9KbfpxAgXeyoG	Student	VCXPA2rGUno5sLdrSz4prcii5vJEJvlF7Bi596d_WcSdymnAhw7usJJG6atMkiag5JTxBAeHZ0ZRF_uTNjkFbg	2025-12-05 00:27:10.062661+00	\N	97d4a227-0c7a-4d37-a138-7afc284dd2c1
019aa366-67f4-7600-86ea-31703aba7f0c	student	student@example.com	$2a$11$U.BtbvIBOc.AYkOYiRcR/e8nXZpZ.Q8xGpzCr995VdohRCHtRHMgu	Student	84_RO367Iu9prEF28kpZYm5GDyWi5fFrvFFaE5dlkXph-DtDKQNkr79GDfpLp0wPa5XZ3qzc4JF4myK4ccbyRg	2025-12-07 16:00:09.749847+00	\N	9d866ea9-5874-4bbe-85fd-c8e4bfe6c566
019aa3c2-c480-7a3d-a562-15008c505312	admin2	admin2@example.com	$2a$11$sczukPsuhEbWH68H7EsN/OMzow3DYOVJPMBQPIDtQvgNv22FUveqO	Admin	A-QC3euQZgHxvHG6AN9bcN_wGPiUtjNTkW3-K7JGd6NuuEEmqUBGIIsjPtV_O0XFFB3N6-F-vM2G2hgMRNrobA	2025-12-08 17:45:54.076836+00	\N	aa815e2f-ec0c-41e4-b382-f0e5e1cce031
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: elearning2user
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20251120214227_InitialCreate	9.0.1
20251121003529_InitialCreate2	9.0.1
20251123153909_CertificateTable	9.0.1
20251124231159_RailwayConnect	9.0.1
20251125124340_RailwayDeploy	9.0.1
20251126005714_RailwayDeploy2	9.0.1
20251126040449_RailwayDeploy3	9.0.1
20251126044339_RailwayDeploy5	9.0.1
20251126044440_RailwayDeploy6	9.0.1
\.


--
-- Name: Certificates PK_Certificates; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Certificates"
    ADD CONSTRAINT "PK_Certificates" PRIMARY KEY ("Id");


--
-- Name: Courses PK_Courses; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Courses"
    ADD CONSTRAINT "PK_Courses" PRIMARY KEY ("Id");


--
-- Name: Enrollments PK_Enrollments; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Enrollments"
    ADD CONSTRAINT "PK_Enrollments" PRIMARY KEY ("Id");


--
-- Name: Lessons PK_Lessons; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Lessons"
    ADD CONSTRAINT "PK_Lessons" PRIMARY KEY ("Id");


--
-- Name: Students PK_Students; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Students"
    ADD CONSTRAINT "PK_Students" PRIMARY KEY ("Id");


--
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Certificates_StudentId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE UNIQUE INDEX "IX_Certificates_StudentId" ON public."Certificates" USING btree ("StudentId");


--
-- Name: IX_Certificates_StudentId1; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE INDEX "IX_Certificates_StudentId1" ON public."Certificates" USING btree ("StudentId1");


--
-- Name: IX_Courses_TeacherId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE INDEX "IX_Courses_TeacherId" ON public."Courses" USING btree ("TeacherId");


--
-- Name: IX_Enrollments_CourseId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE INDEX "IX_Enrollments_CourseId" ON public."Enrollments" USING btree ("CourseId");


--
-- Name: IX_Enrollments_StudentId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE INDEX "IX_Enrollments_StudentId" ON public."Enrollments" USING btree ("StudentId");


--
-- Name: IX_Lessons_CourseId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE INDEX "IX_Lessons_CourseId" ON public."Lessons" USING btree ("CourseId");


--
-- Name: IX_Students_UserId; Type: INDEX; Schema: public; Owner: elearning2user
--

CREATE UNIQUE INDEX "IX_Students_UserId" ON public."Students" USING btree ("UserId");


--
-- Name: Certificates FK_Certificates_Students_StudentId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Certificates"
    ADD CONSTRAINT "FK_Certificates_Students_StudentId" FOREIGN KEY ("StudentId") REFERENCES public."Students"("Id") ON DELETE CASCADE;


--
-- Name: Certificates FK_Certificates_Students_StudentId1; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Certificates"
    ADD CONSTRAINT "FK_Certificates_Students_StudentId1" FOREIGN KEY ("StudentId1") REFERENCES public."Students"("Id");


--
-- Name: Courses FK_Courses_Users_TeacherId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Courses"
    ADD CONSTRAINT "FK_Courses_Users_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Enrollments FK_Enrollments_Courses_CourseId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Enrollments"
    ADD CONSTRAINT "FK_Enrollments_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES public."Courses"("Id") ON DELETE CASCADE;


--
-- Name: Enrollments FK_Enrollments_Students_StudentId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Enrollments"
    ADD CONSTRAINT "FK_Enrollments_Students_StudentId" FOREIGN KEY ("StudentId") REFERENCES public."Students"("Id") ON DELETE CASCADE;


--
-- Name: Lessons FK_Lessons_Courses_CourseId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Lessons"
    ADD CONSTRAINT "FK_Lessons_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES public."Courses"("Id") ON DELETE CASCADE;


--
-- Name: Students FK_Students_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: elearning2user
--

ALTER TABLE ONLY public."Students"
    ADD CONSTRAINT "FK_Students_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

\unrestrict gsbnNBDQIffE2ZknPzDicgSk9CZWsoc779dmHfy933pLdMKgfg2uwcGhqSglPoF

