CREATE TABLE Book (
    UID        CHAR (32)     PRIMARY KEY
                             NOT NULL,
    Title      VARCHAR (100) NOT NULL,
    Alias      VARCHAR (100),
    Author     VARCHAR (100),
    Note       VARCHAR (100),
    Rate       INTEGER       DEFAULT (0) 
                             NOT NULL,
    DeleteFlag INTEGER       DEFAULT (0) 
                             NOT NULL
);


CREATE TABLE Version (
    UID           CHAR (32) PRIMARY KEY
                            NOT NULL,
    BookID        CHAR (32) NOT NULL
                            REFERENCES Book (UID),
    VersionNo     INTEGER   NOT NULL
                            DEFAULT (1),
    Content       TEXT      NOT NULL,
    ContentHash   CHAR (32) NOT NULL,
    ContentLength INTEGER   NOT NULL,
    DeleteFlag    INTEGER   NOT NULL
                            DEFAULT (0) 
);


CREATE TABLE Line (
    UID        CHAR (32) PRIMARY KEY
                         NOT NULL,
    VersionID  CHAR (32) REFERENCES Version (UID) 
                         NOT NULL,
    LineNo     INTEGER   NOT NULL
                         DEFAULT (1),
    Content    TEXT      NOT NULL,
    DeleteFlag INTEGER   NOT NULL
                         DEFAULT (0) 
);
