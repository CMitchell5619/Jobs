USE acontractorsTale;

-- DROP TABLE jobs;

-- CREATE TABLE jobs(
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   commander VARCHAR(255) DEFAULT 'This is a commander',
--   defense INT NOT NULL,

--   PRIMARY KEY (id)
-- );

-- ALTER TABLE jobs
-- ADD bio VARCHAR(255) DEFAULT 'Some default val';

-- TRUNCATE TABLE jobs
-- to clear out the data and then you can make with correct columns


-- ALTER TABLE jobs
-- DROP COLUMN bio;

-- DROP TABLE contractors;


-- CREATE TABLE contractors
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   kingdomCred INT NOT NULL,
--   jobId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (jobId)
--     REFERENCES jobs (id)
--     ON DELETE CASCADE
-- )