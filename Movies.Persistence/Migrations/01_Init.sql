

CREATE TABLE director(
                         id UUID PRIMARY KEY,
                         first_name VARCHAR(100) NOT NULL,
                         last_name VARCHAR(100) NOT NULL,
                         birth_day DATE NOT NULL,
                         biography VARCHAR(500) NOT NULL,
                         photo VARCHAR NOT NULL,
    
                         UNIQUE (first_name, last_name, birth_day)
);


CREATE TABLE movie (
                       id UUID PRIMARY KEY,
                       title VARCHAR(100) NOT NULL,
                       release_year INT NOT NULL,
                       country VARCHAR(100) NOT NULL,
                       budget INT,
                       score INT NOT NULL,
                       director_id UUID NOT NULL,
                       description VARCHAR(500) NOT NULL,
                       photo VARCHAR NOT NULL,

                       UNIQUE (title, release_year),
                       FOREIGN KEY (director_id) REFERENCES director (id) ON DELETE CASCADE,
                       CHECK ( score >= 1 AND score <= 10 )
);


CREATE TABLE genre(
                      id UUID PRIMARY KEY,
                      title VARCHAR(100) NOT NULL,

                      UNIQUE (title)
);


CREATE TABLE movie_genre(
                            movie_id UUID NOT NULL,
                            genre_id UUID NOT NULL,

                            PRIMARY KEY (movie_id, genre_id),
                            FOREIGN KEY (movie_id) REFERENCES movie (id) ON DELETE CASCADE,
                            FOREIGN KEY (genre_id) REFERENCES genre (id) ON DELETE CASCADE
);