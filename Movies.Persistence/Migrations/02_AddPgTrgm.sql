

CREATE EXTENSION IF NOT EXISTS pg_trgm;

CREATE INDEX idx_genre_title_trgm ON genre USING GIN (title gin_trgm_ops);

CREATE INDEX idx_director_name_trgm ON director USING GIN (first_name gin_trgm_ops, last_name gin_trgm_ops);

CREATE INDEX idx_movie_title_trgm ON movie USING GIN (title gin_trgm_ops);


